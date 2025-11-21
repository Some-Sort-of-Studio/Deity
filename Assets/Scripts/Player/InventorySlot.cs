using UnityEngine;

public class InventorySlot : PlayerInventory
{
    public UnityEngine.UI.Image IconSprite;
    public string TomeTitle;
    private static Tome SlotTome;

    private void Start()
    {
        SlotTome = null;
        IconSprite.sprite = null;
        TomeTitle = null;
    }

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

        if (!AlterOpen())
            base.ReadTome(SlotTome);

        if (AlterOpen())
        {
            if(selectedTome = null)
            {
                selectedTome = SlotTome;
            }
            else selectedTome = null;
        }
    }
}
