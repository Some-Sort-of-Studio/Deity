using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tome", order = 1)]
public class Tome : ScriptableObject
{
    public string TomeName;
    public Sprite TomeSprite;
    public Sprite TomeIcon;
}
