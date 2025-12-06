using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UnityEngine.UI.Image Icon;
    [SerializeField] private Tome tomeInSlot;

    public void CreateSlot(Tome WhatItem)
    {
        Icon.sprite = WhatItem.TomeIcon;
        tomeInSlot = WhatItem;
    }

    // view the tome or select the tome
    public void ViewTome()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory playerInv = player.GetComponent<PlayerInventory>();

        // for alter selection
        if (playerInv.alteropened)
            playerInv.SetTome(tomeInSlot);

        // for reading tome
        if (!playerInv.alteropened)
        {
            if (!playerInv.tomeopened)
            {
                playerInv.ReadTome(tomeInSlot);
            }
            else
            {
                playerInv.PlayTomeAnim();
            }
        }
    }
}
