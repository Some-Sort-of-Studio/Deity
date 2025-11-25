using System.Collections.Generic;
using UnityEngine;

public class AlterScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject AlterCanvas;
    [SerializeField] protected GameObject PrayButton;


    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;

    private List<Tome> TomesInAlter = new List<Tome>();

    public static PlayerInventory playerInv;

    private bool playerOverlapping = false;

    private void Start()
    {
        PrayButton.SetActive(false);
        AlterCanvas.SetActive(false);
        playerOverlapping = false;

        playerInv = GameObject.FindFirstObjectByType<PlayerInventory>();
    }

    private void Update()
    {
        if(playerInv == null)
        {
            playerInv = GameObject.FindFirstObjectByType<PlayerInventory>();
        }

        if (Input.GetKeyUp(KeyCode.W) && playerOverlapping)
        {
            if(AlterCanvas.activeSelf)
            {
                OnAlterDisable();
            }
            else
            {
                OnAlterEnable();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOverlapping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOverlapping = false;
        }
    }

    public void OnAlterEnable()
    {
        AlterCanvas.SetActive(true);
        playerInv.AlterOpen(true);
    }

    public void OnAlterDisable()
    {
        AlterCanvas.SetActive(false);
        playerInv.CloseInventory();
        playerInv.AlterOpen(false);
    }

    public void Pray()
    {
        OnAlterDisable();

        if(TomesInAlter.Count == 3)
        {
            CheckForEndings();
        }
    }

    public void AddtoAlter(Tome tome, bool remove = false)
    {
        if (remove)
        {
            TomesInAlter.Remove(tome);
        }
        else
        {
            TomesInAlter.Add(tome);
        }

        if (TomesInAlter.Count == 3)
        {
            PrayButton.SetActive(true);
        }
        else PrayButton.SetActive(false);
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
