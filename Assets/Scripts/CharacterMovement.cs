using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region Variables
    GameObject Player;
    /// <summary>
    /// The two variables used for determining movement directions
    /// movingUp triggers an upward movement when positive and a downward movement when negative
    /// movingLeft triggers horizontal movement based on when it is positive or negative
    /// </summary>
    public float movingUp;
    public float movingRight;

    [SerializeField]
    public Transform StartPos;

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

    [SerializeField]
    private GameObject InteractCircle;
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
        Player = gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
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
        movingRight = 0f;

        movingRight = Input.GetAxis("Horizontal");

        movingUp = Input.GetAxis("Vertical");

        movingRight *= MovementSpeed;

        movingUp *= MovementSpeed;



        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(Input.GetButtonDown("Interact"))
        {
            InteractCircle.GetComponent<InteractSphereController>().Activate();
        }

        return (movingUp != 0 || movingRight != 0);
    }

    /// <summary>
    /// Method to move the player by 
    /// leveraging the character controller move method
    /// </summary>
    private void Move()
    {
        if (isSprinting)
            gameObject.transform.Translate(new Vector3(movingRight + (movingRight * SprintSpeed), movingUp + (movingUp * SprintSpeed), 0) * Time.deltaTime);
        else
            gameObject.transform.Translate(new Vector3(movingRight, movingUp, 0) * Time.deltaTime);
    }
}
