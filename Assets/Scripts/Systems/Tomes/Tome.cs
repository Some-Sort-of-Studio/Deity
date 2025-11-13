using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tome", order = 1)]
public class Tome : ScriptableObject
{
    [Header("Tome Name:")]
    public string TomeName;

    [Header("Tome Sprites")]
    public Sprite TomeSprite;
    public Sprite TomeIcon;

    [Header("Tome Text")]
    [TextArea] public string TomeText;
}
