using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ManipulateWater : MonoBehaviour
{
    [SerializeField] private float maxPaintDistance = 8;
    [SerializeField] private GameObject waterPaintPrefab;

    private Water currentWater;
    private GameObject lastPaintedWater;

    public void ManipulateWaterAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentWater = FindNearestWater();
            if (currentWater == null) { return; }

            if(context.duration % 2 == 0)
            {
                if (!currentWater.empty)
                {
                    PaintWater();
                }
            }
        }

        if (context.canceled)
        {
            lastPaintedWater = null;
        }
    }

    private void PaintWater()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);

        GameObject closestWaterThing = lastPaintedWater != null ? lastPaintedWater : currentWater.gameObject;

        float drainAmount = Vector3.Distance(closestWaterThing.transform.position, mousePosition) / currentWater.transform.localScale.x;
        currentWater.Drain(drainAmount);

        lastPaintedWater = Instantiate(waterPaintPrefab, mousePosition, Quaternion.identity);
        WaterBlob lastPaintedWaterComp = lastPaintedWater.GetComponent<WaterBlob>();
        lastPaintedWaterComp.waterSource = currentWater;
        lastPaintedWaterComp.drainAmount = drainAmount;
    }

    private Water FindNearestWater()
    {
        Water[] watersInScene = FindObjectsByType<Water>(0);

        Water nearestWater = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Water water in watersInScene)
        {
            float waterDistance = Vector3.Distance(transform.position, water.transform.position);

            if (waterDistance < nearestDistance)
            {
                nearestWater = water;
                nearestDistance = waterDistance;
            }
        }

        if (nearestDistance > maxPaintDistance) { return null; }
        return nearestWater;
    }
}
