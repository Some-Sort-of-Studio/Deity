using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;
    private List<Tome> collectedTomes;

    [SerializeField] private Canvas InventoryHolder;
    [SerializeField] private GameObject SlotPrefab;

    private void Awake()
    {
        collectedTomes = new List<Tome>();
    }

    public void CollectTome(Tome tome)
    {
        collectedTomes.Add(tome);
        CheckForEndings();
    }

    private void CheckForEndings()
    {
        foreach (TomeSet tomeSet in existingTomesets)
        {
            bool hasSet = true;

            foreach (Tome tome in tomeSet.tomes)
            {
                //if cant find one of the tomes then dont have set
                if (!collectedTomes.Contains(tome)){ hasSet = false; }
            }

            //if has whole set show ending for that tomeset
            if (hasSet)
            {
                Instantiate(tomeSet.endingCanvas, null);
                return;
            }
        }
    }
}
