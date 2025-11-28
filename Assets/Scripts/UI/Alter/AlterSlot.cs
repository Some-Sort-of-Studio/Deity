using System.Collections;
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
        playerInv = GameObject.FindFirstObjectByType<PlayerInventory>();

        state = SlotState.empty;
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
            StartCoroutine(ButtonDelay());
            TomeInSlot = playerInv.selectedTome;
            playerInv.RemovedFromInventory(TomeInSlot);
            AddtoAlter(TomeInSlot);
            playerInv.SetTome(null);

            state = SlotState.holding;
        }
    }

    private void TakeFromAlter()
    {
        StartCoroutine(ButtonDelay());
        if (playerInv.selectedTome != null) playerInv.SetTome(null);

        playerInv.AddToInventory(TomeInSlot);
        RemoveFromAlter(TomeInSlot);
        TomeInSlot = null;

        state = SlotState.empty;
    }

    IEnumerator ButtonDelay()
    {
        yield return new WaitForSecondsRealtime(0.05f);
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
