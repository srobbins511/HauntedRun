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
    #endregion


    /// <summary>
    /// initializes the characeter controller reference and stores the current position at the
    /// start
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        currentPos = gameObject.transform;
        Player = gameObject;
        TargetLocation = gameObject.transform.position;
        prevLocation = gameObject.transform.position;
        targetLocationReached = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(targetLocationReached)
            checkInputs();
        Move();
        
    }

    /// <summary>
    /// Checks the inputs registered everyframe to determine if the player should move
    /// returns a bool value as to whether the character needs to move
    /// </summary>
    /// <returns></returns>
    private void checkInputs()
    {
        
        movingRight = Input.GetAxisRaw("Horizontal");
        if(movingRight == 1)
        {
            Quaternion interactZone = InteractCircle.transform.rotation;
            interactZone.eulerAngles = new Vector3(0, 0, 90);
        } else if(movingRight == -1) {
            Quaternion interactZone = InteractCircle.transform.rotation;
            interactZone.eulerAngles = new Vector3(0, 0, -90);
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
        targetLocationReached = false;
        
    }

    /// <summary>
    /// Method to move the player by 
    /// leveraging the character controller move method
    /// </summary>
    private void Move()
    {
        /*
        if (isSprinting)
            gameObject.transform.Translate(new Vector3(movingRight + (movingRight * SprintSpeed), movingUp + (movingUp * SprintSpeed), 0) * Time.deltaTime);
        else
            gameObject.transform.Translate(new Vector3(movingRight, movingUp, 0) * Time.deltaTime);
            */
        Debug.Log("Move Called");
        gameObject.transform.position = new Vector3 (Mathf.Lerp(gameObject.transform.position.x, TargetLocation.x, MovementSpeed), Mathf.Lerp(gameObject.transform.position.y, TargetLocation.y, MovementSpeed));
        if(Mathf.Abs(gameObject.transform.position.x- TargetLocation.x) <= .5f && Mathf.Abs(gameObject.transform.position.y - TargetLocation.y) <= .5f)
        {
            targetLocationReached = true;
            prevLocation = TargetLocation;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        TargetLocation = prevLocation;
    }

    public void onDeath()
    {
        gameObject.transform.position = StartPos.position;
        TargetLocation = StartPos.position;
    }
}
