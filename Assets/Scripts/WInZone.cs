using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInZone : MonoBehaviour
{
    private GameObject LevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
            LevelManager.GetComponent<LevelManager>().OnComplete();
    }
}
