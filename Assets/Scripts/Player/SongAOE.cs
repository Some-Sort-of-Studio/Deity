using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SongAOE : MonoBehaviour
{
    public GameObject AOE;

    public KeyCode AOETrigger = KeyCode.Q;
    void Update()
    {
        if (Input.GetKey(AOETrigger))
        {
            AOE.SetActive(true);
        }
        else
        {
            AOE.SetActive(false);
        }
    }
}
