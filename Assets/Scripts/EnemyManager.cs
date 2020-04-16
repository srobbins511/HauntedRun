using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> Enemies;

    public Coroutine EnemyAI;
    void Awake()
    {
        Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        EnemyAI = StartCoroutine(EnemyMovement());
    }
        

    IEnumerator EnemyMovement()
    {
        yield return new WaitUntil(EnemiesInstantiated);
        while (true)
        {
            foreach(GameObject e in Enemies)
            {
                switch (e.GetComponent<EnemyController>().state)
                {
                    //default movement option
                    case 0:
                        Debug.Log("Enemy move called");
                        e.GetComponent<EnemyController>().Move();
                        break;
                    case 1:
                        e.GetComponent<EnemyController>().Chase();
                        break;
                }
            }
            Debug.Log("Coroutine called");
            yield return new WaitForFixedUpdate();
        }
    }

    public bool EnemiesInstantiated()
    {
        return Enemies[0].GetComponent<EnemyController>().targetWaypoint != null;
    }
}
