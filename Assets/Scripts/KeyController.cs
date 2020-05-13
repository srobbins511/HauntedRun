using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public bool collected = false;

    private GameObject LevelManager;

    public AudioClip Keysound;


    public void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            collected = true;
            LevelManager.GetComponent<LevelManager>().OnKeyCollect();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(Keysound, transform.position);
        }

    }
}
