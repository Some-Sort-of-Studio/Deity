using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class DrownInBigWater : MonoBehaviour
{
    [SerializeField] private GameObject drowningEffectObject;

    [SerializeField] private float maxSwimmableWaterHeight = 2;
    [SerializeField] private float timeToDrown = 1.5f;

    private PlayerHealth playerHealth;
    private bool drowning;

    private void Awake()
    {
        drowningEffectObject.SetActive(false);
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we entered water that is over Xm high then DROWN!!! after Y seconds
        if (collision.gameObject.GetComponent<Water>() != null)
        {
            if(collision.gameObject.GetComponent<BoxCollider2D>()?.size.y * collision.transform.localScale.y > maxSwimmableWaterHeight && !drowning)
            {
                StartCoroutine(nameof(Drown));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if we left the water then we aren't drowning anymore
        if (collision.gameObject.GetComponent<Water>() != null)
        {
            drowningEffectObject.SetActive(false);
            drowning = false;
        }
    }

    private IEnumerator Drown()
    {
        drowning = true;
        drowningEffectObject.SetActive(true);

        //if still drowning after time to drown then ded
        yield return new WaitForSeconds(timeToDrown);
        if (drowning) 
        { 
            playerHealth.StartCoroutine(nameof(playerHealth.Die)); 
            drowningEffectObject.SetActive(false);
            drowning = false;
        }
    }
}
