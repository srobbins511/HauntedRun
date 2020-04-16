using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZone : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = null;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            player = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            player = null;
        }
    }
}
