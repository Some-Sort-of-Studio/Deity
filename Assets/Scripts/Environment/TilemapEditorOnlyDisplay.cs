using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent (typeof(TilemapRenderer))]
public class TilemapEditorOnlyDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        TilemapRenderer tilemapRenderer = GetComponent<TilemapRenderer>();
#if UNITY_EDITOR
        tilemapRenderer.enabled = true;
#else
        tilemapRenderer.enabled = false;
#endif
    }
}
