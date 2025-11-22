using JetBrains.Annotations;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public UnityEngine.UI.Image IconSprite;
    public string TomeTitle;
    public Tome SlotTome;

    public void AddToSlot(Tome tome)
    {
        SlotTome = tome;
        IconSprite.sprite = tome.TomeIcon;
        TomeTitle = tome.TomeName;
    }

    // view the tome or select the tome
    public void ViewTome()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory playerInv = player.GetComponent<PlayerInventory>();

        // for alter selection
        if (playerInv.alteropened)
        {
            playerInv.selectedTome = SlotTome;
        }

        // for reading tome
        if (!playerInv.alteropened)
        {
            playerInv.ReadTome(SlotTome);
        }
    }
}
