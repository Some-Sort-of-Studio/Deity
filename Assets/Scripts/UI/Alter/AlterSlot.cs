using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlterSlot : MonoBehaviour
{
    // state of the slot
    private enum SlotState { holding, empty }

    private PlayerInventory playerInv;
    private SlotState state;

    [Header("References:")]
    [SerializeField] private Image SlotIcon;
    [SerializeField] private Image SlotImage;
    [SerializeField] private Sprite SlotHolding;
    [SerializeField] private Sprite SlotEmpty;

    [Header("Tome Held:")]
    [SerializeField] private Tome TomeInSlot;

    private void Start()
    {
        playerInv = GameObject.FindFirstObjectByType<PlayerInventory>();

        state = SlotState.empty;
        SlotChange();
    }

    // this thing is a mess...too bad!
    public void AddToSlot()
    {
        switch (state)
        {
            case SlotState.empty:
                TomeInSlot = null;
                AddToEmpty();
                SlotChange();
                return;

            case SlotState.holding:
                TakeFromAlter();
                SlotChange();
                return;
        }
    }
    private void AddToEmpty()
    {
        if (playerInv.selectedTome != null)
        {
            TomeInSlot = playerInv.selectedTome;
            playerInv.RemovedFromInventory(TomeInSlot);
            playerInv.SetTome(null);

            state = SlotState.holding;
        }
    }

    private void TakeFromAlter()
    {
        if (playerInv.selectedTome != null) playerInv.SetTome(null);

        playerInv.AddToInventory(TomeInSlot);
        TomeInSlot = null;

        state = SlotState.empty;
    }

    private void SlotChange()
    {
        if (TomeInSlot != null)
        {
            SlotIcon.sprite = TomeInSlot.TomeIcon;
            SlotImage.sprite = SlotHolding;
        }
        else
        {
            SlotIcon.sprite = null;
            SlotImage.sprite = SlotEmpty;
        }
    }
}
