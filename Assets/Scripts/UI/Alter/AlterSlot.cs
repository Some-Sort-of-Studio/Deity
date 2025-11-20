using UnityEngine;
using UnityEngine.UI;

public class AlterSlot : PlayerInventory
{
    [SerializeField] private Image SlotImage;
    [SerializeField] private string SlotName;

    [SerializeField] private Tome TomeInSlot;

    public void AddToSlot()
    {
        // if no tome selected then nothing happens
        if (selectedTome == null)
        {
            return;
        }
        // if no there is a tome and theres a selected tome
        else if (TomeInSlot != null && selectedTome != null)
        {
            TomeInSlot = selectedTome;
            RemovedFromInventory(selectedTome);
            CollectTome(TomeInSlot);
            selectedTome = null;

            SlotChange();
        }
        // is theres a tome in slot and no selected tome
        else if (TomeInSlot != null && selectedTome == null)
        {
            CollectTome(TomeInSlot);
            TomeInSlot = null;
            SlotChange();
        }
        // other
        else
        {
            TomeInSlot = selectedTome;
            RemovedFromInventory(TomeInSlot);
            selectedTome = null;
            SlotChange();
        }
    }

    private void SlotChange()
    {
        if(TomeInSlot != null)
        {
            SlotImage.sprite = TomeInSlot.TomeIcon;
            SlotName = TomeInSlot.TomeName;
        }
        else
        {
            SlotImage.sprite = null;
            SlotName = "";
        }
    }
}
