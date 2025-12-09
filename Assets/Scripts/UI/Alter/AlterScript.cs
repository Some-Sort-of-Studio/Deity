using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlterScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject AlterCanvas;
    [SerializeField] protected GameObject PrayButton;
    [SerializeField] private Animator animator;


    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;
    [SerializeField] private TomeSet currentSet;

    [SerializeField] private List<Tome> TomesInAlter = new List<Tome>();

    [SerializeField]

    public static PlayerInventory playerInv;

    private bool playerOverlapping = false;

    private void Start()
    {
        PrayButton.SetActive(false);
        AlterCanvas.SetActive(false);
        playerOverlapping = false;
        currentSet = null;

        playerInv = GameObject.FindFirstObjectByType<PlayerInventory>();
    }

    private void Update()
    {
        if (playerInv == null)
        {
            playerInv = GameObject.FindFirstObjectByType<PlayerInventory>();
        }

        if (Input.GetKeyUp(KeyCode.W) && playerOverlapping)
        {
            if (AlterCanvas.activeSelf)
            {
                animator.SetBool("AltarOpen", false);
                Invoke(nameof(OnAlterDisable), 0.2f);
            }
            else
            {
                animator.SetBool("AltarOpen", true);
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
        Instantiate(currentSet.endingCanvas, null);
        UIManager.Instance.TogglePlayerAbilities(false);
    }

    public void RemoveFromAlter(Tome tome)
    { 
        TomesInAlter.Remove(tome);
        PrayButton.SetActive(false);
        currentSet = null;
    }

    public void AddtoAlter(Tome tome)
    {
        TomesInAlter.Add(tome);

        if (TomesInAlter.Count == 3)
        {
            CheckForEndings();
        }
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
                    currentSet = null;
                }
            }

            //if has whole set show ending for that tomeset
            if (hasSet)
            {
                PrayButton.SetActive(true);
                currentSet = tomeSet;
                return;
            }
        }
    }
}
