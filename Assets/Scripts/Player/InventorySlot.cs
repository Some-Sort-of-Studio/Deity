using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private UnityEngine.UI.Image IconSprite;
    public string TomeTitle;
    private Tome SlotTome;

    public void AddToSlot(Tome tome)
    {
        SlotTome = tome;
        IconSprite.sprite = tome.TomeIcon;
        TomeTitle = tome.TomeName;
    }

    public void ViewTome()
    {
        gameObject.GetComponentInParent<PlayerInventory>().ReadTome(SlotTome);
    }
}
