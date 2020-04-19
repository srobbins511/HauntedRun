using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZone : MonoBehaviour
{
    public GameObject player;

    public bool isNestedInEnemy;
    public bool canSeePlayer;
    protected virtual void Start()
    {
        player = null;
        if(gameObject.GetComponentInParent<EnemyController>() != null)
        {
            isNestedInEnemy = true;
        }
    }

    // Update is called once per frame
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log(collision.gameObject.name);
        if(collision.tag.Equals("Player"))
        {
            Debug.Log("Player Detected");
            player = collision.gameObject;
            canSeePlayer = true;
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
            canSeePlayer = false;
            if (isNestedInEnemy)
            {
                gameObject.GetComponentInParent<EnemyController>().checkZone(gameObject);
            }
        }
    }
}
