using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UnityEngine.UI.Image Icon;
    [SerializeField] private Tome tomeInSlot;

    public void EmptySlot()
    {
        Icon.enabled = false;
    }

    public void CreateSlot(Tome WhatItem)
    {
        if (WhatItem == null)
        {
            EmptySlot();
            return;
        }

        Icon.enabled = true;

        Icon.sprite = WhatItem.TomeIcon;
    }

    // view the tome or select the tome
    public void ViewTome()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory playerInv = player.GetComponent<PlayerInventory>();

        // for alter selection
        if (playerInv.alteropened)
        {
            playerInv.SetTome(tomeInSlot);
        }

        // for reading tome
        if (!playerInv.alteropened)
        {
            playerInv.ReadTome(tomeInSlot);
        }
    }
}
