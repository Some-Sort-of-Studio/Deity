using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharacterDatabase characterDB;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI ability1Text;
    [SerializeField] private TextMeshProUGUI ability2Text;

    private int selectedOption = 0;

    [SerializeField] private Animator animator;
    [SerializeField] private string StartingLevel;

    private void Start()
    {
        selectedOption = 0;
        Save();

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
        Rotate();
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
        Reverse();
        Save();
    }

    private void UpdatedCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        nameText.text = character.characterName;
        titleText.text = character.characterTitle;
        descriptionText.text = character.characterDescription;
        ability1Text.text = character.characterAbility1;
        ability2Text.text = character.characterAbility2;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void PlayGame()
    {
        UIManager.Instance.StartGame();
    }

    private void Rotate()
    {
        if (selectedOption == 1)
        {
            animator.SetBool("Rotate(CtoO)", true);
            animator.SetBool("Rotate(OtoC)", false);
            animator.SetBool("Reverse(CtoO)", false);
            animator.SetBool("Reverse(OtoC)", false);
        }
        else if (selectedOption == 0)
        {
            animator.SetBool("Rotate(CtoO)", false);
            animator.SetBool("Rotate(OtoC)", true);
            animator.SetBool("Reverse(CtoO)", false);
            animator.SetBool("Reverse(OtoC)", false);
        }
    }

    private void Reverse()
    {
        if (selectedOption == 1)
        {
            animator.SetBool("Rotate(CtoO)", false);
            animator.SetBool("Rotate(OtoC)", false);
            animator.SetBool("Reverse(CtoO)", true);
            animator.SetBool("Reverse(OtoC)", false);
        }
        else if (selectedOption == 0)
        {
            animator.SetBool("Rotate(CtoO)", false);
            animator.SetBool("Rotate(OtoC)", false);
            animator.SetBool("Reverse(CtoO)", false);
            animator.SetBool("Reverse(OtoC)", true);
        }
    }
}
