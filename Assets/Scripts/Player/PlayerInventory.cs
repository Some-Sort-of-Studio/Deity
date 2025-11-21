using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Tome> collectedTomes = new List<Tome>();
    private bool opened = false;

    #region TomeViewer
    [Header("Inventory References:")]
    [SerializeField] protected GameObject InventoryHolder;
    [SerializeField] protected GameObject SlotPrefab;

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

    protected AlterScript alterScript;

    public Tome selectedTome;

    private void Start()
    {
        tomeCanvas.TomeViewer.SetActive(false);
        tomeCanvas.TomeViewerClean.SetActive(false);
        InventoryHolder.gameObject.SetActive(false);

        alterScript = GameObject.Find("Alter").GetComponent<AlterScript>();
    }

    public void CollectTome(Tome tome)
    {
        collectedTomes.Add(tome);
    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!opened && !AlterOpen())
            {
                UIManager.Instance.TogglePlayerAbilities(false);
                InventoryHolder.gameObject.SetActive(true);
                UpdateInventory();
                opened = true;
            }
            else
            {
                UIManager.Instance.TogglePlayerAbilities(true);
                CloseInventory();
                CloseTome();
                opened = false;
            }
        }
    }

    public bool AlterOpen(bool isopen = false)
    {
        if(isopen)
        {
            UIManager.Instance.TogglePlayerAbilities(false);
            InventoryHolder.gameObject.SetActive(true);
            UpdateInventory();
            opened = isopen;
            return isopen;
        }
        else
        {
            UIManager.Instance.TogglePlayerAbilities(true);
            CloseInventory();
            opened = isopen;
            return isopen;
        }
    }

    private void UpdateInventory()
    {
        foreach (Tome tome in collectedTomes)
        {
            Instantiate(SlotPrefab, InventoryHolder.transform);
            SlotPrefab.GetComponent<InventorySlot>().AddToSlot(tome);
        }
    }

    public void CloseInventory()
    {
        foreach (Transform children in InventoryHolder.transform)
        {
            Destroy(children.gameObject);
        }

        InventoryHolder.gameObject.SetActive(false);
    }

    // makes tome viewer readable
    public void ReadTome(Tome tome)
    {
        tomeCanvas.TomeViewer.SetActive(true);
        tomeCanvas.TomeText.text = tome.TomeText;

        // TODO: REWORKKKK
        if (tomeCanvas.TomeViewer.activeSelf && Input.GetKey(KeyCode.Tab))
        {
            tomeCanvas.TomeViewerClean.SetActive(true);
            tomeCanvas.TomeTextClean.text = tome.TomeText;
        }
        else
        {
            tomeCanvas.TomeViewerClean.SetActive(false);
            tomeCanvas.TomeTextClean.text = "";
        }
    }

    // closes the tome viewer
    public void CloseTome()
    {
        tomeCanvas.TomeViewer.SetActive(false);
        tomeCanvas.TomeText.text = "";

        tomeCanvas.TomeViewerClean.SetActive(false);
        tomeCanvas.TomeTextClean.text = "";
    }

    public void RemovedFromInventory(Tome tometoremove)
    {
        foreach(Tome tome in collectedTomes)
        {
            if(tome == tometoremove)
            {
                collectedTomes.Remove(tome);
            }
        }
    }
}
