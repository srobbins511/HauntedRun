using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActivationManager : MonoBehaviour
{
    public GameObject ControlledGhosts;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        Debug.Log(collision.tag);
        if (collision.tag.Equals("Player") && gameObject.CompareTag("GhostActivator"))
        {
            Debug.Log("Player interacted With");
            ControlledGhosts.SetActive(true);
            GameManager.Instance.enemyManager.FindGhosts();
        }
        else if (collision.tag.Equals("Player") && gameObject.CompareTag("GhostDeactivator"))
        {
            Debug.Log("Player interacted With");
            ControlledGhosts.SetActive(false);
            GameManager.Instance.enemyManager.FindGhosts();
        }
    }

   
}
