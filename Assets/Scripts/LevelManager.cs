﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Keys;


    [SerializeField]
    private string NextLevel;

    public int keyIndex = 0;

    public int KeyMax;


    public void Awake()
    {
        Keys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Collectable")); 
        KeyMax = GameObject.FindGameObjectsWithTag("Collectable").Length;
        GameManager.Instance.Instatiate();
    }

    public void OnKeyCollect()
    {
        Debug.Log("On Key Collect");
        keyIndex++;
    }


    public void OnComplete()
    {
        Debug.Log("Called");
        Debug.Log(CheckKeys());
        if(CheckKeys())
        {
            GameManager.Instance.LoadLevel(NextLevel);
        }
    }

    public void AddKey(GameObject key)
    {
        Debug.Log("Key added");
        Keys.Add(key);
        KeyMax++;
        GameManager.Instance.Instatiate();
    }
    public bool CheckKeys()
    {
        return keyIndex >= KeyMax;
    }
}
