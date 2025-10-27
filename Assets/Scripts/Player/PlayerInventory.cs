using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Tome> collectedTomes;

    private void Awake()
    {
        collectedTomes = new List<Tome>();
    }

    public void CollectTome(Tome tome)
    {
        collectedTomes.Add(tome);
    }
}
