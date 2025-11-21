using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public UnityEngine.UI.Image IconSprite;
    public string TomeTitle;
    private Tome SlotTome;

    public void AddToSlot(Tome tome)
    {
        SlotTome = tome;
        IconSprite.sprite = tome.TomeIcon;
        TomeTitle = tome.TomeName;
    }

    public bool CheckTome(Tome tome)
    {
        if (SlotTome == null)
            return true;
        else return false;
    }

    public void ViewTome()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerInventory playerInv = player.GetComponent<PlayerInventory>();

        if (!playerInv.AlterOpen())
            playerInv.ReadTome(SlotTome);

        if (playerInv.AlterOpen())
        {
            if(playerInv.selectedTome = null)
            {
                playerInv.selectedTome = SlotTome;
            }
            else playerInv.selectedTome = null;
        }
    }
}
