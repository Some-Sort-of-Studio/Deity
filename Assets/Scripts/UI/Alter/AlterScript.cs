using UnityEngine;

public class AlterScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject AlterCanvas;
    [SerializeField] private GameObject Player;

    [Header("Lists and Arrays")]
    [Tooltip("This var should include all potential sets in the game")]
    [SerializeField] private TomeSet[] existingTomesets;

    private void Start()
    {
        AlterCanvas.SetActive(false);
    }

    public void OnAlterEnable()
    {
        AlterCanvas.SetActive(true);

        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void CheckForEndings()
    {
    //    foreach (TomeSet tomeSet in existingTomesets)
    //    {
    //        bool hasSet = true;

    //        foreach (Tome tome in tomeSet.tomes)
    //        {
    //            //if cant find one of the tomes then dont have set
    //            if (!collectedTomes.Contains(tome)) { hasSet = false; }
    //        }

    //        //if has whole set show ending for that tomeset
    //        if (hasSet)
    //        {
    //            Instantiate(tomeSet.endingCanvas, null);
    //            return;
    //        }
    //    }
    }
}
