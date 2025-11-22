using System.Collections;
using AudioSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ManipulateWater : MonoBehaviour
{
    [SerializeField] private float delayBetweenPainting = 1;
    [SerializeField] private float maxPaintDistance = 8;
    [SerializeField] private GameObject waterPaintPrefab;

    private bool painting;

    private Water currentWater;
    private GameObject lastPaintedWater;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = waterPaintPrefab.GetComponent<AudioSource>();
    }

    public void ManipulateWaterAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            painting = true;
            StartCoroutine("PaintWater");
        }

        if (context.canceled)
        {
            painting = false;
            lastPaintedWater = null;
        }
    }

    private IEnumerator PaintWater()
    {
        currentWater = FindNearestWater();
        if (currentWater != null)
        {
            while (painting && !currentWater.empty)
            {
                DrawWater();
                AudioManager.Instance.PlayAudio("WaterMoving", audioSource);
                yield return new WaitForSeconds(delayBetweenPainting);
            }
        }
    }

    private void DrawWater()
    {
        GameObject closestWaterThing = lastPaintedWater != null ? lastPaintedWater : currentWater.gameObject;

        float drainAmount = Vector3.Distance(closestWaterThing.transform.position, transform.position) / currentWater.transform.localScale.x;
        currentWater.Drain(drainAmount);

        lastPaintedWater = Instantiate(waterPaintPrefab, closestWaterThing.transform.position, Quaternion.identity);
        WaterBlob lastPaintedWaterComp = lastPaintedWater.GetComponent<WaterBlob>();
        lastPaintedWaterComp.destPosition = transform.position;
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
