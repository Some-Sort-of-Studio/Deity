using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public SpriteRenderer playerSprite;
    public TextMeshProUGUI ability1Text;
    public TextMeshProUGUI ability2Text;

    private int selectedOption = 0;

    [SerializeField] private string StartingLevel;

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
        playerSprite.sprite = character.characterSprite;
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

    public void PlayGame()
    {
        UIManager.Instance.StartGame();
    }
}
