using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class TentacleGrabber : MonoBehaviour
{
    //tentacle's position and length will be between these two points
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject boxHolder;

    private GrabObjects grabObjects;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        grabObjects = playerObject.GetComponent<GrabObjects>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (grabObjects.isTryingGrab)
        {
            float grabberDistance = Vector3.Distance(playerObject.transform.position, boxHolder.transform.position);
            transform.position = transform.parent.position + transform.up * (grabberDistance < 0.1f ? 1.5f : grabberDistance / 2);
            transform.localScale = new Vector3(transform.localScale.x, (grabberDistance < 0.1f ? 1 : grabberDistance / 2), transform.localScale.y);
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
