using UnityEngine;

public class AlterRoom : MonoBehaviour
{
    [Tooltip("Make sure you put all stars in here so the script can check them")]
    [SerializeField] private GameObject[] Stars;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject star in Stars)
        {
            star.GetComponent<AlterStars>().CheckforTome(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject star in Stars)
        {
            star.GetComponent<AlterStars>().StopAnim();
        }
    }
}
