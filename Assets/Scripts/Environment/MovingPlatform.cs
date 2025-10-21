using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;

    private Vector3 nextPosition;

    public enum PlatformType
    { 
        Automatic,
        Trigger,
        Switch_Cycle,
        Switch_Single
    }

    public PlatformType type;

    private bool isPlayerOnPlatform;

    public bool isSwitchOn;


    private void Start()
    {
        if (type == PlatformType.Automatic || type == PlatformType.Switch_Cycle)
        {
            nextPosition = pointB.position;
        }
    }

    private void Update()
    {
        if (type == PlatformType.Automatic)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

            if (transform.position == nextPosition)
            {
                nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
            }
        }

        if (type == PlatformType.Trigger)
        {
            if (isPlayerOnPlatform)
            {
                nextPosition = pointB.position;
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            }
            else if (!isPlayerOnPlatform)
            {
                nextPosition = pointA.position;
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            }
        }

        if (type == PlatformType.Switch_Cycle)
        {
            if (isSwitchOn)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

                if (transform.position == nextPosition)
                {
                    nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
                }
            }
        }

        if (type == PlatformType.Switch_Single)
        {
            if (isSwitchOn)
            {
                nextPosition = pointB.position;
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            }
            else if (!isSwitchOn)
            {
                nextPosition = pointA.position;
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    public void switchToggle()
    {
        if (type == PlatformType.Switch_Cycle)
        {
            if (!isSwitchOn)
            {
                isSwitchOn = true;
            }
        }

        if (type == PlatformType.Switch_Single)
        {
            if (isSwitchOn)
            {
                isSwitchOn = false;
            }
            else if (!isSwitchOn)
            {
                isSwitchOn = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;

            if (type == PlatformType.Trigger)
            {
                isPlayerOnPlatform = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;

            if (type == PlatformType.Trigger)
            {
                isPlayerOnPlatform = false;
            }
        }
    }

}
