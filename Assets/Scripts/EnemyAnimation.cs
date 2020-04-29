using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyController
{

    void FixedUpdate()
    {
        //Here is the way that i think the states can be set.
        //I made the Path variable public for this, It is a Unit Vector that determines which direction the enemy moves
        //So by checking its x and y components one can determine which way the enemy is going
        //the state variable is the one that determines in what way the enemy moves with negative one meaning that the enemy is not moving
        #region Updated States

        if ((Path.x != 0 || Path.y != 0) && state != -1)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (Path.x > 0)
        {
            animator.SetBool("IsMovingRight", true);
            animator.SetBool("IsMovingLeft", false);
        }
        else if (Path.x < 0)
        {
            animator.SetBool("IsMovingLeft", true);
            animator.SetBool("IsMovingRight", false);
        }

        if (Path.y > 0)
        {
            animator.SetBool("IsMovingUp", true);
            animator.SetBool("IsMovingDown", false);
        }
        else if (Path.y < 0)
        {
            animator.SetBool("IsMovingUp", false);
            animator.SetBool("IsMovingDown", true);
        }
        #endregion


    }
}
