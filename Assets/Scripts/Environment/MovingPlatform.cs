using System.Runtime.CompilerServices;
using AudioSystem;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;

    private Vector3 nextPosition;

    private AudioSource audioSource;

    public enum PlatformType
    { 
        Automatic,
        Trigger,
        Puzzle_Cycle,
        Puzzle_Single
    }

    public enum TriggerType
    {
        Switch,
        Pressure_Plate
    }

    public PlatformType platform_type;
    public TriggerType trigger_type;

    private bool isPlayerOnPlatform;

    public bool isSwitchOn;
    public bool isPressurePlateActive;


    private void Start()
    {
        if (platform_type == PlatformType.Automatic || platform_type == PlatformType.Puzzle_Cycle)
        {
            nextPosition = pointB.position;
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (platform_type == PlatformType.Automatic)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

            if (transform.position == nextPosition)
            {
                nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
                AudioManager.Instance.PlayAudio("MovingPlatforms", audioSource);
            }
        }

        if (platform_type == PlatformType.Trigger)
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

        if (platform_type == PlatformType.Puzzle_Cycle)
        {
            if (isSwitchOn)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

                if (transform.position == nextPosition)
                {
                    nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
                    AudioManager.Instance.PlayAudio("MovingPlatforms", audioSource);
                }
            }
        }

        if (platform_type == PlatformType.Puzzle_Single)
        {
            if (trigger_type == TriggerType.Switch)
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
            
            if (trigger_type == TriggerType.Pressure_Plate)
            {
                if (isPressurePlateActive)
                {
                    nextPosition = pointB.position;
                    transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
                }
                else if (!isPressurePlateActive)
                {
                    nextPosition = pointA.position;
                    transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
                }
            }
        }
    }

    public void switchToggleOn()
    {
        isSwitchOn = true;
        AudioManager.Instance.PlayAudio("MovingPlatforms", audioSource);
    }

    public void switchToggleOff()
    {
        isSwitchOn = false;
        AudioManager.Instance.StopAudio(audioSource);
    }

    public void pressurePlateToggleOn()
    {
        isPressurePlateActive = true;
        AudioManager.Instance.PlayAudio("MovingPlatforms", audioSource);
    }

    public void pressurePlateToggleOff()
    {
        isPressurePlateActive = false;
        AudioManager.Instance.StopAudio(audioSource);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
            collision.gameObject.GetComponent<AudioSource>().enabled = false;
            AudioManager.Instance.PlayAudio("MovingPlatforms", audioSource);

            if (platform_type == PlatformType.Trigger)
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
            collision.gameObject.GetComponent<AudioSource>().enabled = true;
            AudioManager.Instance.StopAudio(audioSource);

            if (platform_type == PlatformType.Trigger)
            {
                isPlayerOnPlatform = false;
            }
        }
    }

}
