using System.Collections.Generic;
using UnityEngine;

public class AlterScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject AlterCanvas;

    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;

    [HideInInspector] public List<Tome> TomesInAlter = new List<Tome>();

    [SerializeField] protected PlayerInventory playerInv;

    private bool playerOverlapping = false;

    private void Start()
    {
        AlterCanvas.SetActive(false);
        playerOverlapping = false;

        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && playerOverlapping && !playerInv.AlterOpen())
        {
            OnAlterEnable();
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

    //public void InteractionWithAlter(InputAction.CallbackContext context)
    //{
    //    if (playerOverlapping && context.performed)
    //    {
    //        OnAlterEnable();
    //    }
    //}


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
