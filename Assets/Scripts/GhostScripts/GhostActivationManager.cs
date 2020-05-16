using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActivationManager : MonoBehaviour
{
    public GameObject ControlledGhosts;


    public void Start()
    {
        //Reset();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && gameObject.CompareTag("GhostActivator") && !ControlledGhosts.activeInHierarchy)
        {
            ControlledGhosts.SetActive(true);
            GameManager.Instance.enemyManager.FindGhosts();
            
        }
        else if (collision.tag.Equals("Player") && gameObject.CompareTag("GhostDeactivator") && ControlledGhosts.activeInHierarchy)
        {
            ControlledGhosts.SetActive(false);
            GameManager.Instance.enemyManager.FindGhosts();
        }
    }

    public void Reset()
    {
        if (ControlledGhosts != null)
        {
            ControlledGhosts.SetActive(false);
        }
    }

   
}
