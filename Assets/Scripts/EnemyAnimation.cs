using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyController
{
    public Animator animator;

    void FixedUpdate()
    {
        //Here is the way that i think the states can be set.
        //I made the Path variable public for this, It is a Unit Vector that determines which direction the enemy moves
        //So by checking its x and y components one can determine which way the enemy is going
        //the state variable is the one that determines in what way the enemy moves with negative one meaning that the enemy is not moving
        #region Updated States
        /*
        if ((Path.x != 0 || Path.y != 0) && state != -1 )
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if(Path.x > 0)
        {
            animator.SetBool("IsMovingRight", true);
            animator.SetBool("IsMovingLeft", false);
        } else if(Path.x < 0)
        {
            animator.SetBool("IsMovingLeft", true);
            animator.SetBool("IsMovingRight", false);
        }

        if(Path.y > 0)
        {
            animator.SetBool("IsMovingUp", true);
            animator.SetBool("IsMovingDown", false);
        } else if (Path.y < 0)
        {
            animator.SetBool("IsMovingUp", false);
            animator.SetBool("IsMovingDown", true);
        }*/
        #endregion

        float wpX = 0f;
        float wpY = 0f;

        if (currentWaypoint == 0)
        {
            GameObject waypoint1 = GameObject.Find("Waypoint1");
            wpX = waypoint1.transform.position.x;
            wpY = waypoint1.transform.position.y;

        }
        else if (currentWaypoint == 1)
        {
            GameObject waypoint2 = GameObject.Find("Waypoint2");
            wpX = waypoint2.transform.position.x;
            wpY = waypoint2.transform.position.y;
        }

        //moving horizontal

        if (curPosition.position.x != wpX)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (curPosition.position.x > wpX)
        {
            animator.SetBool("IsMovingLeft", true);
        }
        else
        {
            animator.SetBool("IsMovingLeft", false);
        }

        if (curPosition.position.x < wpX)
        {
            animator.SetBool("IsMovingRight", true);
        }
        else
        {
            animator.SetBool("IsMovingRight", false);
        }

        //moving vertical

        if (curPosition.position.y != wpY)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (curPosition.position.y > wpY)
        {
            animator.SetBool("IsMovingDown", true);
        }
        else
        {
            animator.SetBool("IsMovingDown", false);
        }

        if (curPosition.position.y < wpY)
        {
            animator.SetBool("IsMovingUp", true);
        }
        else
        {
            animator.SetBool("IsMovingUp", false);
        }


    }
}
