using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> Enemies;

    private bool resetAI;

    public Coroutine EnemyAI;
    void Awake()
    {
        Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        EnemyAI = StartCoroutine(EnemyMovement());
    }

    public void resetGhostStates()
    {
        foreach(GameObject e in Enemies)
        {
            e.GetComponent<EnemyController>().ResetState();
        }
    }
        

    IEnumerator EnemyMovement()
    {
        yield return new WaitUntil(EnemiesInstantiated);
        while (true)
        {
            if (GameManager.Instance.Paused)
            {
                foreach (GameObject e in Enemies)
                {
                    switch (e.GetComponent<EnemyController>().state)
                    {
                        //default movement option
                        case -1:
                            break;
                        case 0:
                            e.GetComponent<EnemyController>().Move();
                            break;
                        case 1:
                            e.GetComponent<EnemyController>().Chase();
                            break;
                    }
                    if (e.GetComponent<EnemyController>().killedPlayer)
                    {
                        e.GetComponent<EnemyController>().killedPlayer = false;
                        e.GetComponent<EnemyController>().ResetState();
                    }
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public bool EnemiesInstantiated()
    {
        return Enemies[0].GetComponent<EnemyController>().targetWaypoint != null;
    }

    public void FindGhosts()
    {
        Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }
}
