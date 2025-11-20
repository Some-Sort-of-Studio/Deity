using System;
using System.Collections.Generic;
using UnityEngine;

public class AlterScript : PlayerInventory
{
    [Header("References")]
    [SerializeField] private GameObject AlterCanvas;

    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;

    [HideInInspector] public List<Tome> TomesInAlter = new List<Tome>();


    private void Start()
    {
        AlterCanvas.SetActive(false);
    }

    public void OnAlterEnable()
    {
        AlterCanvas.SetActive(true);
        AlterOpen();
    }

    public void OnAlterDisable()
    {
        AlterCanvas.SetActive(false);
        CloseInventory();
        AlterOpen(false);
    }

    public void Pray()
    {
        OnAlterDisable();
        CheckForEndings();
    }

    public void AddtoAlter(Tome tome)
    {
        //TomesInAlter.Add(tome);
    }

    public void CheckForEndings()
    {
        foreach (TomeSet tomeSet in existingTomesets)
        {
            bool hasSet = true;

            foreach (Tome tome in tomeSet.tomes)
            {
                //if cant find one of the tomes then dont have set
                if (!TomesInAlter.Contains(tome))
                {
                    hasSet = false; 
                }
            }

            //if has whole set show ending for that tomeset
            if (hasSet)
            {
                //Instantiate(tomeSet.endingCanvas, null);
                return;
            }
        }
    }
}
