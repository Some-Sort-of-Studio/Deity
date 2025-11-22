using UnityEngine;
using UnityEngine.UI;

public class AlterSlot : AlterScript
{
    // state of the slot
    private enum SlotState { holding, empty }
    private SlotState state;

    [Header("References:")]
    [SerializeField] private Image SlotImage;
    [SerializeField] private string SlotName;

    [Header("Tome Held:")]
    [SerializeField] private Tome TomeInSlot;

    private void Start()
    {
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        state = SlotState.empty;
    }

    // this thing is a mess...too bad!
    public void AddToSlot()
    {
        if (state == SlotState.empty)
        {
            // set tome in alter and remove from player inventory
            TomeInSlot = playerInv.selectedTome;
            playerInv.RemovedFromInventory(playerInv.selectedTome);
            playerInv.selectedTome = null;

            // add to the alter slot list and change state
            AddtoAlter(TomeInSlot, false);
            state = SlotState.holding;
            SlotChange();

            return;
        }

        // if already holding a tome
        if (state == SlotState.holding)
        {
            // if the player has selected a tome already
            if (playerInv.selectedTome != null)
            {
                Tome tome = TomeInSlot;
                TomeInSlot = playerInv.selectedTome; // sets the tome in the slot
                playerInv.selectedTome = tome; // temp store of selected tome
                playerInv.CollectTome(tome);
                tome = null;

                AddtoAlter(TomeInSlot, false);
                SlotChange();
            }
            // if the player has not selected tome
            else
            {
                playerInv.CollectTome(TomeInSlot);
                playerInv.UpdateInventory();
                AddtoAlter(TomeInSlot, true);
                TomeInSlot = null;

                state = SlotState.empty;
                SlotChange();
            }

            return;
        }
    }

    private void SlotChange()
    {
        if (TomeInSlot != null)
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
