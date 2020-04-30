using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetection : ChaseZone
{
    public GameObject wall;
    public Vector3 direction;
    
    public List<RaycastHit2D> results;

    public float disengageTime;


    public float startChaseDelay;

    private Coroutine AgroTimer;
    private Coroutine ChaseTimer;


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
            if (AgroTimer != null) StopCoroutine(AgroTimer);
            player = collision.gameObject;
            playerLocation = player.transform;
            canSeePlayer = false;
            direction = player.transform.position - gameObject.transform.position;
            RaycastHit2D r = Physics2D.Raycast(gameObject.transform.position, direction, direction.magnitude,GameManager.Instance.BlockViewFilter.layerMask);
            if(r.collider == null)
            {
                canSeePlayer = true;
            }
            else if(gameObject.GetComponentInParent<EnemyController>().state == 1)
            {
                AgroTimer = StartCoroutine(LoseAgroTimer());
            }

            if (canSeePlayer && gameObject.GetComponentInParent<EnemyController>().state != 1)
            {
                ChaseTimer = StartCoroutine(StartChaseTimer());
                gameObject.GetComponentInParent<EnemyController>().state = -1;
            }
            
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        canSeePlayer = false;
        if(AgroTimer == null)
            AgroTimer = StartCoroutine(LoseAgroTimer());
    }

    IEnumerator LoseAgroTimer()
    {
        if(ChaseTimer != null)StopCoroutine(ChaseTimer);
        float time = 0;
        while(!canSeePlayer && time < disengageTime)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(time >= disengageTime)
        {
            player = null;
            gameObject.GetComponentInParent<EnemyController>().checkZone(gameObject);
        }
        StopCoroutine(AgroTimer);
    }
    IEnumerator StartChaseTimer()
    {
        if(AgroTimer != null)StopCoroutine(AgroTimer);
        float time = 0;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
        while (canSeePlayer && time < startChaseDelay)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (time >= startChaseDelay)
        {
            gameObject.GetComponentInParent<EnemyController>().checkZone(gameObject);
        }
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        StopCoroutine(ChaseTimer);
    }
}
