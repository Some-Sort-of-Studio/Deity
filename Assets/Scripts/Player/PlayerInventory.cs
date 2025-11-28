using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Tome> collectedTomes = new List<Tome>();
    private bool opened = false;
    [HideInInspector] public bool alteropened = false;

    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;

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

        // clean version
        public GameObject TomeViewerClean;
        public TextMeshProUGUI TomeTextClean;
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
        tomeCanvas.TomeViewerClean.SetActive(false);
        InventoryHolder.SetActive(false);

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
    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            if (!opened && !alteropened)
            {
                OpenInventory();
                opened = true;
            }
            else if (!alteropened)
            {
                CloseInventory();
                opened = false;
            }
        }
    }

    // toggles the inventory for the alter
    public void AlterOpen(bool isopen = false)
    {
        if (isopen == true)
        {
            OpenInventory();
            alteropened = isopen;
        }
        else
        {
            CloseInventory();
            alteropened = isopen;
        }
    }

    public void OpenInventory()
    {
        UpdateInventory();
        UIManager.Instance.TogglePlayerAbilities(false);
        InventoryHolder.SetActive(true);
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
            Instantiate(SlotPrefab, InventoryHolder.transform);
            SlotPrefab.GetComponent<InventorySlot>().CreateSlot(tome);
        }
    }

    public void CloseInventory()
    {
        CloseTome();
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
        tomeCanvas.TomeText.text = tome.TomeText;
    }

    // closes the tome viewer
    public void CloseTome()
    {
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
