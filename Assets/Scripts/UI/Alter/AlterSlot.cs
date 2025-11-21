using UnityEngine;
using UnityEngine.UI;

public class AlterSlot : AlterScript
{
    [SerializeField] private Image SlotImage;
    [SerializeField] private string SlotName;

    [SerializeField] private Tome TomeInSlot;

    private void Start()
    {
        SlotImage = null;
        SlotName = "";
    }

    public void AddToSlot()
    {
        // if no tome selected then nothing happens
        if (playerInv.selectedTome == null)
        {
            return;
        }
        // if no there is a tome and theres a selected tome
        else if (TomeInSlot != null && playerInv.selectedTome != null)
        {
            TomeInSlot = playerInv.selectedTome;
            playerInv.RemovedFromInventory(playerInv.selectedTome);
            playerInv.CollectTome(TomeInSlot);
            playerInv.selectedTome = null;

            SlotChange();
        }
        // is theres a tome in slot and no selected tome
        else if (TomeInSlot != null && playerInv.selectedTome == null)
        {
            playerInv.CollectTome(TomeInSlot);
            TomeInSlot = null;
            SlotChange();
        }
        // other
        else
        {
            TomeInSlot = playerInv.selectedTome;
            playerInv.RemovedFromInventory(TomeInSlot);
            playerInv.selectedTome = null;
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
