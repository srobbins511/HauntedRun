using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement_AnimationTest : CharacterMovement
{
    

    public Animator animator;

    // Update is called once per frame

    /// <summary>
    /// Checks the inputs registered everyframe to determine if the player should move
    /// returns a bool value as to whether the character needs to move
    /// </summary>
    /// <returns></returns>
    protected override void checkInputs()
    {
        base.checkInputs();
        
        //idle animation check
        if (Mathf.Abs(movingUp) < 1 && Mathf.Abs(movingRight) < 1)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }

        //up animation
        if (movingUp >= 1)
        {
            animator.SetBool("IsMovingUp", true);
        }
        else
        {
            animator.SetBool("IsMovingUp", false);
        }

        //down animation
        if (movingUp <= -1)
        {
            animator.SetBool("IsMovingDown", true);
        }
        else
        {
            animator.SetBool("IsMovingDown", false);
        }

        //right animation
        if (movingRight >= 1)
        {
            animator.SetBool("IsMovingRight", true);
        }
        else
        {
            animator.SetBool("IsMovingRight", false);
        }

        //left animation
        if (movingRight <= -1)
        {
            animator.SetBool("IsMovingLeft", true);
        }
        else
        {
            animator.SetBool("IsMovingLeft", false);
        }

    }

    
}
