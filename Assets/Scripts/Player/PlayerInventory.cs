using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;
    private List<Tome> collectedTomes = new List<Tome>();

    // slot references
    [SerializeField] private GameObject InventoryHolder;
    [SerializeField] private GameObject SlotPrefab;

    private bool opened = false;

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

    [SerializeField] TomeCanvas tomeCanvas;

    private void Start()
    {
        tomeCanvas.TomeViewer.SetActive(false);
        tomeCanvas.TomeViewerClean.SetActive(false);
        InventoryHolder.gameObject.SetActive(false);
    }

    public void CollectTome(Tome tome)
    {
        collectedTomes.Add(tome);
        CheckForEndings();
    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(!opened)
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

    private void CheckForEndings()
    {
        foreach (TomeSet tomeSet in existingTomesets)
        {
            bool hasSet = true;

            foreach (Tome tome in tomeSet.tomes)
            {
                //if cant find one of the tomes then dont have set
                if (!collectedTomes.Contains(tome)) { hasSet = false; }
            }

            //if has whole set show ending for that tomeset
            if (hasSet)
            {
                Instantiate(tomeSet.endingCanvas, null);
                return;
            }
        }
    }

    public void ReadTome(Tome tome)
    {
        tomeCanvas.TomeViewer.SetActive(true);
        tomeCanvas.TomeText.text = tome.TomeText;

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

    public void CloseTome()
    {
        tomeCanvas.TomeViewer.SetActive(false);
        tomeCanvas.TomeText.text = "";

        tomeCanvas.TomeViewerClean.SetActive(false);
        tomeCanvas.TomeTextClean.text = "";
    }
}
