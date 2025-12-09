using UnityEngine;

public class TooltipIfCharacter : MonoBehaviour
{
    enum WhichCharacter
    {
        Bird, 
        Octopus
    }

    GameObject playerObject;
    [SerializeField] private WhichCharacter whichCharacter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindFirstObjectByType<PlayerMovement2D>().gameObject;
        if((playerObject.GetComponent<WindBlast>() && whichCharacter == WhichCharacter.Octopus)
            || (playerObject.GetComponent<ManipulateWater>() && whichCharacter == WhichCharacter.Bird))
        {
            Destroy(gameObject);
        }
    }
}
