using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI ability1Text;
    public TextMeshProUGUI ability2Text;

    private int selectedOption = 0;

    private Animator animator;

    [SerializeField] private string StartingLevel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        UpdatedCharacter(selectedOption);

        animator = GetComponentInParent<Animator>();
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
