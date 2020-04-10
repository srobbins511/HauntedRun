﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public bool collected = false;

    private GameObject LevelManager;


    public void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        collected = true;
        LevelManager.GetComponent<LevelManager>().OnKeyCollect();
        Destroy(gameObject);
    }
}
