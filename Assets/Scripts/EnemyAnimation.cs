using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyController
{
    public Animator animator;

    void FixedUpdate()
    {
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
