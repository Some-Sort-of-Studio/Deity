using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TomeSet", order = 2)]
public class TomeSet : ScriptableObject
{
    public string _name;
    public Tome[] tomes;

    public GameObject endingCanvas;
}
