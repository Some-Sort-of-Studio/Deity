using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;
    private List<Tome> collectedTomes = new List<Tome>();

    [SerializeField] private Canvas InventoryHolder;
    [SerializeField] private GameObject SlotPrefab;

    [System.Serializable]
    public struct TomeCanvas
    {
        public GameObject TomeViewer;
        public TextMeshPro TomeText;

        public GameObject TomeViewerClean;
        public TextMeshPro TomeTextClean;
    }

    [SerializeField] TomeCanvas tomeCanvas;

    private void Start()
    {
        InventoryHolder.gameObject.SetActive(false);

        tomeCanvas.TomeViewer.SetActive(false);
        tomeCanvas.TomeViewerClean.SetActive(false);
    }

    public void CollectTome(Tome tome)
    {
        collectedTomes.Add(tome);
        CheckForEndings();
    }

    public void OpenInventory()
    {
        InventoryHolder.gameObject.SetActive(true);

        foreach (Tome tome in collectedTomes)
        {
            Instantiate(SlotPrefab, InventoryHolder.transform);
            SlotPrefab.GetComponent<InventorySlot>().AddToSlot(tome);
        }
    }

    public void CloseInventory()
    {
        foreach (Tome tome in collectedTomes)
        {
            Destroy(SlotPrefab);
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
}
