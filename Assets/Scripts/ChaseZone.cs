using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZone : MonoBehaviour
{
    public GameObject player;

    private bool isNestedInEnemy;
    void Start()
    {
        player = null;
        if(gameObject.GetComponentInParent<EnemyController>() != null)
        {
            isNestedInEnemy = true;
        }
    }

    // Update is called once per frame
    public void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log(collision.gameObject.name);
        if(collision.tag.Equals("Player"))
        {
            Debug.Log("Player Detected");
            player = collision.gameObject;
            if(isNestedInEnemy)
            {
                gameObject.GetComponentInParent<EnemyController>().checkZone(gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            player = null;
            if (isNestedInEnemy)
            {
                gameObject.GetComponentInParent<EnemyController>().checkZone(gameObject);
            }
        }
    }
}
