using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public TextMeshPro nameText;
    public TextMeshPro descriptionText;
    public GameObject playerObject;
    public TextMeshPro ability1Text;
    public TextMeshPro ability2Text;

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
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdatedCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdatedCharacter(selectedOption);
        Save();
    }

    private void UpdatedCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        playerObject = character.characterPrefab;
        nameText.text = character.characterName;
        descriptionText.text = character.characterDescription;
        ability1Text.text = character.characterAbility1;
        ability2Text.text = character.characterAbility2;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
