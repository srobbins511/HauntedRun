using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Keys;

    private int keyIndex = 0;

    private int KeyMax;


    public void Start()
    {
        KeyMax = Keys.Count;
    }

    public void OnKeyCollect()
    {
        Debug.Log("On Key Collect");
        keyIndex++;
    }

    private bool CheckKeys()
    {
        return keyIndex >= KeyMax;
    }
}
