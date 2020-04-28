using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicLayerTile : Tile
{

    public int Layer;
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        Debug.Log("Refresh Called");
        base.RefreshTile(position, tilemap);
        if(GameManager.Instance.Player.transform.position.y <= position.y)
        {
            tilemap.GetComponent<SpriteRenderer>().renderingLayerMask = GameManager.Instance.Player.GetComponent<SpriteRenderer>().renderingLayerMask-1;
        }
        else
        {
            tilemap.GetComponent<SpriteRenderer>().renderingLayerMask = GameManager.Instance.Player.GetComponent<SpriteRenderer>().renderingLayerMask + 1;
        }
    }

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/RoadTile")]
    public static void CreateDynamicLayerTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save DynamicLayer Tile", "New DynamicLayer Tile", "Asset", "Save DynamicLayer Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<DynamicLayerTile>(), path);
    }
#endif
}
