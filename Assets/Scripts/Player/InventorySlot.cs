using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private UnityEngine.UI.Image IconSprite;
    public string TomeTitle;
    private Tome SlotTome;
    [SerializeField] private GameObject TomeViewer;

    public void AddToSlot(Tome tome)
    {
        SlotTome = tome;
        IconSprite.sprite = tome.TomeIcon;
        TomeTitle = tome.TomeName;
    }

    public void ViewTome()
    {
        TomeViewer.SetActive(true);
    }
}
