using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    #region Variables
    [SerializeField]
    [Tooltip("The list of waypoints that the enemy will move too, Enemies will go to each waypoint in order, Waypoints should not be children of the GameObject this script is attached too")]
    private List<Transform> Waypoints;

    private Transform curPosition;

    public int currentWaypoint;

    private int numWayPoints;

    public Transform targetWaypoint;

    private bool WayPointSwitched;

    private Vector3 Path;

    public int state;

    [SerializeField]
    [Tooltip("How fast the enemy will move, will be a very low value greater than zero")]
    private float movementSpeed;

    private Vector3 tolerance = new Vector3(.5f, .5f, .5f);
    #endregion


    #region Methods
    /// <summary>
    /// Instantiate the variables that will be used by the scripts
    /// Set the first waypoint
    /// set the waypoint follower index
    /// find the first path
    /// start enemy movement coroutine
    /// </summary>
    void Start()
    {
        state = 0;
        curPosition = gameObject.transform;
        currentWaypoint = 0;
        numWayPoints = Waypoints.Count;
        targetWaypoint = Waypoints[currentWaypoint];
        WayPointSwitched = false;
        findPath();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        switch (other.tag)
        {
            case "Player":
                GameManager.Instance.TriggerDeath();
                break;
            case "ChaseZone":
                if (other.gameObject.GetComponent<ChaseZone>().player != null)
                {
                    state = 1;
                    targetWaypoint = other.gameObject.GetComponent<ChaseZone>().player.transform;
                }
                else
                {
                    state = 0;
                    targetWaypoint = Waypoints[currentWaypoint];
                    findPath();
                }
                break;
        }
        if(other.tag.Equals("Player"))
        {
            GameManager.Instance.TriggerDeath();
        }
    }


    /// <summary>
    /// Coroutine that determines enemy movement
    /// </summary>
    /// <returns></returns>
    public void Move()
    {
        Debug.Log("Enemy has moved");
        //checks to see if the waypoints have changed by looking at flag variable
        if (WayPointSwitched)
        {
            //if yes findd the new path
            findPath();
        }
        //move the enemy down the path
        gameObject.transform.position += Path;

        //save the current position of the enemy
        curPosition = gameObject.transform;

        //checck to seee if the waypoint has been reached
        if (Mathf.Abs(curPosition.position.x - targetWaypoint.position.x) <= 1 && Mathf.Abs(curPosition.position.y - targetWaypoint.position.y) <= 1)
        {
            //if waypoint has been reached, check to see if the way point was the last one in the list
            if(currentWaypoint < numWayPoints-1)
            {
                //if it is not the last one, increment waypoint counter
                currentWaypoint++;
            }
            else
            {
                //if it was the last one reset the waypoint counter
                currentWaypoint = 0;
            }
            //grab the new waypoint from the list using the updated counter
            targetWaypoint = Waypoints[currentWaypoint];

            //change flag variable for if waypoints have been switched
            WayPointSwitched = true;
        }
       
    }

    public void Chase()
    {
        if(state == 1)
        {
            findPath();

            gameObject.transform.position += Path;

            //save the current position of the enemy
            curPosition = gameObject.transform;
        }
    }

    /// <summary>
    /// Method called to find the new path to the next waypoint
    /// only called at start and when waypoints have been switched
    /// </summary>
    /// <returns></returns>
    private Vector3 route()
    {
        //find the change between the x and y positions between the current position of the enemy and
        //the position of the waypoint
        float xDistance = targetWaypoint.position.x - curPosition.position.x;
        float yDistance = targetWaypoint.position.y - curPosition.position.y;

        //find the distance between the current position and the waypoint using the x and y changes
        float JourneyLength = Mathf.Sqrt(Mathf.Pow(xDistance, 2f) + Mathf.Pow(yDistance, 2f));

        //Find the x and  y components of the unit vector in the direction of the waypoint
        float incrementX = xDistance / JourneyLength;
        float incrementy = yDistance / JourneyLength;

        //return the unit vector in the direction of the waypoint
        return new Vector3(incrementX, incrementy, 0);
    }

    /// <summary>
    /// Method the find the path that the enemy will take
    /// </summary>
    private void findPath()
    {
        //use the route method to get the unit vector in the direction of the waypoint
        //then multiply that vector by the enemies speed to get the incremental path
        Path = route() * movementSpeed;

        //change flag variable for if waypoints have been switched
        WayPointSwitched = false;
    }

    private float Magnitude(Vector3 v)
    {
        return Mathf.Sqrt(Mathf.Pow(v.x, 2f) + Mathf.Pow(v.y, 2f) + Mathf.Pow(v.z, 2f));
    }

    #endregion
}
