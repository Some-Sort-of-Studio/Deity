using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TomeSet", order = 2)]
public class TomeSet : ScriptableObject
{
    public string Name;
    public Tome[] Tomes;

    public GameObject EndingCanvas;
}
