using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement_AnimationTest : CharacterMovement
{
    #region Variables
    /*
    GameObject Player;
    /// <summary>
    /// The two variables used for determining movement directions
    /// movingUp triggers an upward movement when positive and a downward movement when negative
    /// movingLeft triggers horizontal movement based on when it is positive or negative
    /// </summary>
    public float movingUp;
    public float movingRight;

    public Grid map;
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

    private Vector3 TargetLocation;
    private Vector3 prevLocation;
    
    [SerializeField]
    private float MovementSpeed = .5f;

    [SerializeField]
    [Tooltip("Increases movement speed by percentage, should be  value between 0 and 1")]
    private float SprintSpeed;

    [SerializeField]
    private GameObject InteractCircle;

    [SerializeField]
    private float offset;
    public bool targetLocationReached;
    */
    #endregion

    public Animator animator;


    /// <summary>
    /// initializes the characeter controller reference and stores the current position at the
    /// start
    /// Start is called before the first frame update
    /// </summary>
    protected override void Start()
    {
        base.Start();
        /*
        currentPos = gameObject.transform;
        Player = gameObject;
        TargetLocation = gameObject.transform.position;
        prevLocation = gameObject.transform.position;
        targetLocationReached = true;
        */
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        /*
        if(targetLocationReached)
            checkInputs();
        Move();
        */
        
    }

    /// <summary>
    /// Checks the inputs registered everyframe to determine if the player should move
    /// returns a bool value as to whether the character needs to move
    /// </summary>
    /// <returns></returns>
    protected override void checkInputs()
    {
        base.checkInputs();
        /*
        movingRight = Input.GetAxisRaw("Horizontal");
        if(movingRight == 1)
        {
            Quaternion interactZone = InteractCircle.transform.rotation;
            interactZone.eulerAngles = new Vector3(0, 0, -90);
        } else if(movingRight == -1) {
            Quaternion interactZone = InteractCircle.transform.rotation;
            interactZone.eulerAngles = new Vector3(0, 0, 90);
        }

        movingUp = Input.GetAxisRaw("Vertical");

        if(movingUp == 1)
        {
            Quaternion interactZone = InteractCircle.transform.rotation;
            interactZone.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(movingUp == -1)
        {
            Quaternion interactZone = InteractCircle.transform.rotation;
            interactZone.eulerAngles = new Vector3(0, 0, 180);
        }
        movingRight *= map.cellSize.x;
        movingUp *= map.cellSize.y;

        if(movingUp != 0 || movingRight != 0)
        {
            TargetLocation = new Vector3(gameObject.transform.position.x + movingRight, gameObject.transform.position.y + movingUp, 0);
            TargetLocation = map.GetCellCenterWorld(map.WorldToCell(TargetLocation));
        }
        */
        
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

        /*
        if (Input.GetKey(KeyCode.LeftShift))
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
        targetLocationReached = false;
        */
    }

    /// <summary>
    /// Method to move the player by 
    /// leveraging the character controller move method
    /// </summary>
    protected override void Move()
    {
        base.Move();
        /*
        if (isSprinting)
            gameObject.transform.Translate(new Vector3(movingRight + (movingRight * SprintSpeed), movingUp + (movingUp * SprintSpeed), 0) * Time.deltaTime);
        else
            gameObject.transform.Translate(new Vector3(movingRight, movingUp, 0) * Time.deltaTime);
            
        Debug.Log("Move Called");
        gameObject.transform.position = new Vector3 (Mathf.Lerp(gameObject.transform.position.x, TargetLocation.x, MovementSpeed), Mathf.Lerp(gameObject.transform.position.y, TargetLocation.y, MovementSpeed));
        if(Mathf.Abs(gameObject.transform.position.x- TargetLocation.x) <= .5f && Mathf.Abs(gameObject.transform.position.y - TargetLocation.y) <= .5f)
        {
            targetLocationReached = true;
            prevLocation = TargetLocation;
        }
        */
    }

    public override void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionStay2D(collision);
        //TargetLocation = prevLocation;
    }

    public override void onDeath()
    {
        base.onDeath();
        /*
        gameObject.transform.position = StartPos.position;
        TargetLocation = StartPos.position;
        */
    }
}
