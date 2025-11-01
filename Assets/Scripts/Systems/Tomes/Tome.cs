using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tome", order = 1)]
public class Tome : ScriptableObject
{
    public string _name;
    public Sprite icon;
}
