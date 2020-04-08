using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> Waypoints;

    private Transform curPosition;

    public Coroutine EnemyMovement;

    private int currentWaypoint;

    private int numWayPoints;

    private Transform targetWaypoint;

    private bool WayPointSwitched;

    private Vector3 Path;

    [SerializeField]
    private float movementSpeed;

    private Vector3 tolerance = new Vector3(.5f, .5f, .5f);
    void Start()
    {
        curPosition = gameObject.transform;
        currentWaypoint = 0;
        numWayPoints = Waypoints.Count;
        targetWaypoint = Waypoints[currentWaypoint];
        WayPointSwitched = false;
        findPath();
        EnemyMovement = StartCoroutine(EnemyMove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyMove()
    {
        while(true)
        {
            if(WayPointSwitched)
            {
                findPath();
            }
            gameObject.transform.position += Path;
            curPosition = gameObject.transform;
            if (Mathf.Abs(curPosition.position.x - targetWaypoint.position.x) <= 1 && Mathf.Abs(curPosition.position.y - targetWaypoint.position.y) <= 1)
            {
                Debug.Log("Waypoint Switching called");

                if(currentWaypoint < numWayPoints-1)
                {
                    currentWaypoint++;
                }
                else
                {
                    currentWaypoint = 0;
                }
                targetWaypoint = Waypoints[currentWaypoint];
                Debug.Log(targetWaypoint.name);
                WayPointSwitched = true;
            }
            yield return new WaitForEndOfFrame();
        }
        
    }

    private Vector3 route()
    {
        float xDistance = targetWaypoint.position.x - curPosition.position.x;
        float yDistance = targetWaypoint.position.y - curPosition.position.y;
        float JourneyLength = Mathf.Sqrt(Mathf.Pow(xDistance, 2f) + Mathf.Pow(yDistance, 2f));
        float incrementX = xDistance / JourneyLength;
        float incrementy = yDistance / JourneyLength;
        return new Vector3(incrementX, incrementy, 0);
    }

    private void findPath()
    {
        Path = route() * movementSpeed;
        WayPointSwitched = false;
    }

    private float Magnitude(Vector3 v)
    {
        return Mathf.Sqrt(Mathf.Pow(v.x, 2f) + Mathf.Pow(v.y, 2f) + Mathf.Pow(v.z, 2f));
    }
}
