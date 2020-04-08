using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// The two variables used for determining movement directions
    /// movingUp triggers an upward movement when positive and a downward movement when negative
    /// movingLeft triggers horizontal movement based on when it is positive or negative
    /// </summary>
    public float movingUp;
    public float movingLeft;

    //a reference to the current position and transform of the player
    public Transform currentPos;

    /// <summary>
    /// Variables that show if a player is moving and
    /// if thier movement is being affected by a sprint command
    /// </summary>
    public bool moved;
    public bool isSprinting;

    //reference to the character controller attached to the player object
    private CharacterController c;

    [SerializeField]
    [Tooltip("Determines how fast that the player will be moving, should be positive")]
    private float MovementSpeed;

    [SerializeField]
    [Tooltip("Increases movement speed by percentage, should be  value between 0 and 1")]
    private float SprintSpeed;

    #endregion


    /// <summary>
    /// initializes the characeter controller reference and stores the current position at the
    /// start
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        c = gameObject.GetComponent<CharacterController>();
        currentPos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(checkInputs())
            Move();
        
    }

    /// <summary>
    /// Checks the inputs registered everyframe to determine if the player should move
    /// returns a bool value as to whether the character needs to move
    /// </summary>
    /// <returns></returns>
    private bool checkInputs()
    {
        movingUp = 0f;
        movingLeft = 0f;


        if(Input.GetKey(KeyCode.W))
        {
            movingUp = MovementSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            movingUp = -MovementSpeed;
        }

        if(Input.GetKey(KeyCode.D))
        {
            movingLeft = MovementSpeed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            movingLeft = -MovementSpeed;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        Debug.Log((movingUp != 0 || movingLeft != 0));
        return (movingUp != 0 || movingLeft != 0);
    }

    /// <summary>
    /// Method to move the player by 
    /// leveraging the character controller move method
    /// </summary>
    private void Move()
    {
        if (isSprinting)
            c.Move(new Vector3(movingLeft + (movingLeft * SprintSpeed), movingUp + (movingUp * SprintSpeed), 0) * Time.deltaTime);
        else
            c.Move(new Vector3(movingLeft, movingUp, 0) * Time.deltaTime);
    }
}
