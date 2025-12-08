using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlterSlot : MonoBehaviour
{
    // state of the slot
    private enum SlotState { holding, empty }

    private PlayerInventory playerInv;
    private AlterScript alterScript;
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
        alterScript = gameObject.GetComponentInParent<AlterScript>();

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
            alterScript.AddtoAlter(TomeInSlot);

            state = SlotState.holding;
        }
    }

    private void TakeFromAlter()
    {
        if (playerInv.selectedTome != null) playerInv.SetTome(null);

        playerInv.AddToInventory(TomeInSlot);
        alterScript.RemoveFromAlter(TomeInSlot);
        TomeInSlot = null;

        state = SlotState.empty;
    }

    private void SlotChange()
    {
        if (TomeInSlot != null)
        {
            SlotIcon.enabled = true;
            SlotIcon.sprite = TomeInSlot.TomeIcon;
            SlotImage.sprite = SlotHolding;
        }
        else
        {
            SlotIcon.enabled = false;
            SlotIcon.sprite = null;
            SlotImage.sprite = SlotEmpty;
        }
    }
}
