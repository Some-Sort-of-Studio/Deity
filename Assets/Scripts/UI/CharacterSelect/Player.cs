using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Vector3 playerSpawnLocation;
    private GameObject player;

    private int selectedOption = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdatedCharacter(selectedOption);
        SpawnPlayer();
    }

    private void UpdatedCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void SpawnPlayer()
    {
        Character character = characterDB.GetCharacter(selectedOption);
        player = character.playerObject;
        Vector3 position = playerSpawnLocation;
        Quaternion playerRotation = Quaternion.identity;
        Instantiate(player, playerSpawnLocation, playerRotation);
        
    }
}
