using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tome", order = 1)]
public class Tome : ScriptableObject
{
    public string Name;
    public Sprite icon;

    [Header ("What sets is this tome a part of") ]
    public string[] Sets;
}
