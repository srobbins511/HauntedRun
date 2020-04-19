using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetection : ChaseZone
{
    public GameObject wall;
    public Vector3 direction;
    public List<RaycastHit2D> results;


    protected override void Start()
    {
        base.Start();
        results = new List<RaycastHit2D>();
    }
    // Start is called before the first frame update
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            player = collision.gameObject;
            canSeePlayer = true;
            direction = player.transform.position - gameObject.transform.position;
            RaycastHit2D r = Physics2D.Raycast(gameObject.transform.position, direction, direction.magnitude,GameManager.Instance.BlockViewFilter.layerMask);
            if(r.collider != null)
            {
                canSeePlayer = false;
            }
            else
            {
                canSeePlayer = true;
            }


            if (canSeePlayer)
            {
                if (isNestedInEnemy)
                {
                    gameObject.GetComponentInParent<EnemyController>().checkZone(gameObject);
                }
            }
            
        }
    }
}
