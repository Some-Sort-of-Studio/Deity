using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Animator invanimator;
    public Animator tomeanimator;

    private List<Tome> collectedTomes = new List<Tome>();
    private bool opened = false;
    [HideInInspector] public bool alteropened = false;
    [HideInInspector] public bool tomeopened = false;

    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;

    #region Tooltips

    [SerializeField] private GameObject openInventoryTooltip;
    [SerializeField] private GameObject viewTomeTooltip;

    #endregion

    #region TomeViewer
    [Header("Inventory References:")]
    [SerializeField] private GameObject InventoryHolder;
    [SerializeField] private GameObject SlotPrefab;

    // tome viewer struct
    [System.Serializable]
    public struct TomeCanvas
    {
        // normal version
        public GameObject TomeViewer;
        public TextMeshProUGUI TomeText;
    }

    [Header("Tome Viewer")]
    [SerializeField] private TomeCanvas tomeCanvas;
    #endregion

    private AlterScript alterScript;

    public bool hasPickedUp;

    public Tome selectedTome;

    private void Start()
    {
        tomeCanvas.TomeViewer.SetActive(false);
        InventoryHolder.SetActive(false);

        openInventoryTooltip.SetActive(false);
        viewTomeTooltip.SetActive(false);

        alterScript = GameObject.Find("Alter").GetComponent<AlterScript>();
    }

    public Tome SetTome(Tome tome)
    {
        if (tome == selectedTome) return selectedTome;
        else
        {
            selectedTome = tome;
            return selectedTome;
        }
    }

    public void CollectTome(Tome tome)
    {
        collectedTomes.Add(tome);

        if (openInventoryTooltip != null) { openInventoryTooltip.SetActive(true); }
    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!opened && !alteropened)
            {
                invanimator.SetBool("InventoryOpen", true);
                OpenInventory();
                opened = true;
            }
            else if (!alteropened)
            {
                invanimator.SetBool("InventoryOpen", false);
                if (viewTomeTooltip != null) { viewTomeTooltip.SetActive(false); }
                Invoke(nameof(CloseInventory), 0.2f);
                opened = false;
            }
        }
    }

    // toggles the inventory for the alter
    public void AlterOpen(bool isopen = false)
    {
        if (isopen == true)
        {
            invanimator.SetBool("InventoryOpen", true);
            OpenInventory();
            if (openInventoryTooltip != null) { Destroy(openInventoryTooltip); }
            if (viewTomeTooltip != null) { viewTomeTooltip.SetActive(true); }
            alteropened = isopen;
        }
        else
        {
            invanimator.SetBool("InventoryOpen", false);
            if (viewTomeTooltip != null) { viewTomeTooltip.SetActive(false); }
            Invoke(nameof(CloseInventory), 0.2f);
            alteropened = isopen;
        }
    }

    public void OpenInventory()
    {
        InventoryHolder.SetActive(true);
        if (openInventoryTooltip != null) { Destroy(openInventoryTooltip); }
        if (viewTomeTooltip != null && collectedTomes.Count > 0) 
        { 
            viewTomeTooltip.SetActive(true); 
        }
        UpdateInventory();
        UIManager.Instance.TogglePlayerAbilities(false);
    }

    public void UpdateInventory()
    {
        SetTome(null);

        foreach (Transform children in InventoryHolder.transform)
        {
            Destroy(children.gameObject);
        }

        foreach (Tome tome in collectedTomes)
        {
            GameObject slot = Instantiate(SlotPrefab, InventoryHolder.transform);
            slot.GetComponent<InventorySlot>().CreateSlot(tome);
        }
    }

    public void CloseInventory()
    {
        if(tomeCanvas.TomeViewer.activeSelf) PlayTomeAnim();

        UIManager.Instance.TogglePlayerAbilities(true);

        foreach (Transform children in InventoryHolder.transform)
        {
            Destroy(children.gameObject);
        }

        InventoryHolder.SetActive(false);
    }

    // makes tome viewer readable
    public void ReadTome(Tome tome)
    {
        tomeCanvas.TomeViewer.SetActive(true);
        tomeanimator.SetBool("TomeOpen", true);

        tomeopened = true;

        tomeCanvas.TomeText.text = tome.TomeText;

        if(viewTomeTooltip != null) { Destroy(viewTomeTooltip); }
    }

    // closes the tome viewer
    public void PlayTomeAnim() // this is bad but it works
    {
        tomeanimator.SetBool("TomeOpen", false);
        Invoke(nameof(CloseTome), 0.5f);
    }

    private void CloseTome()
    {
        tomeopened = false;
        tomeCanvas.TomeViewer.SetActive(false);
        tomeCanvas.TomeText.text = "";
    }

    public void RemovedFromInventory(Tome tometoremove)
    {
        collectedTomes.Remove(tometoremove);
        UpdateInventory();
    }

    public void AddToInventory(Tome tome)
    {
        collectedTomes.Add(tome);
        UpdateInventory();
    }

    public bool CheckInventory(Tome startome)
    {
        foreach (Tome tome in collectedTomes)
        {
            if (startome == tome)
            {
                return true;
            }
        }
        return false;
    }
}
