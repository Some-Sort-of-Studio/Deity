using Mono.Cecil.Cil;
using System;
using UnityEngine;

public class TomeGather : MonoBehaviour
{
    [SerializeField] private Tome tome;

    private void Awake()
    {
        if(tome == null) {Debug.Log("Missing Tome SO reference for", this); Destroy(gameObject); }
    }

    //private void Update()
    //{
    //    transform.Rotate(0, 180 * Time.deltaTime, 0, Space.World);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();
        if (playerInventory != null && !playerInventory.hasPickedUp)
        {
            playerInventory.CollectTome(tome);
            Destroy(gameObject);
        }
    }
}
