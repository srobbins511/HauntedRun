using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    public List<GameObject> Powers;

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
    public bool canMove;
    public bool CanTarget;

    public bool prevMoveDirection;

    public Coroutine protectMovement;
    public int movementCount;

    public int NumLives;

    private List<RaycastHit2D> results;

    public bool dying;
    #endregion


    /// <summary>
    /// initializes the characeter controller reference and stores the current position at the
    /// start
    /// Start is called before the first frame update
    /// </summary>
    protected virtual void Start()
    {
        gameObject.transform.position = map.GetCellCenterWorld(map.WorldToCell(gameObject.transform.position));
        currentPos = gameObject.transform;
        Player = gameObject;
        TargetLocation = gameObject.transform.position;
        prevLocation = gameObject.transform.position;
        canMove = false;
        map = FindObjectOfType<Grid>();
        Powers = new List<GameObject>();
        CanTarget = true;
        results = new List<RaycastHit2D>();
    }


    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if(CanTarget && !GameManager.Instance.Paused && !dying)
            checkInputs();
        if(canMove && !GameManager.Instance.Paused && !dying)
            Move();
        
    }

    /// <summary>
    /// Checks the inputs registered everyframe to determine if the player should move
    /// returns a bool value as to whether the character needs to move
    /// </summary>
    /// <returns></returns>
    protected virtual void checkInputs()
    {
        canMove = true;

        movingRight = Input.GetAxisRaw("Horizontal");

        movingUp = Input.GetAxisRaw("Vertical");

        movingRight *= map.cellSize.x;
        movingUp *= map.cellSize.x;

        if (movingUp != 0 && (movingRight = 0) == 0)
        {
            TargetLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + movingUp, 0);
            TargetLocation = map.GetCellCenterWorld(map.WorldToCell(TargetLocation));
        }

        if (movingRight != 0 && (movingUp = 0) == 0)
        {
            TargetLocation = new Vector3(gameObject.transform.position.x + movingRight, gameObject.transform.position.y, 0);
            TargetLocation = map.GetCellCenterWorld(map.WorldToCell(TargetLocation));
        }
        Vector3 direction = (TargetLocation - gameObject.transform.position);
        RaycastHit2D r = Physics2D.Raycast(gameObject.transform.position, direction, direction.magnitude);
        if(r.collider != null && r.collider.tag.Equals("Interactable"))
        {
            r.collider.GetComponent<Interactable>().Interact();
        }

        if (Input.GetButton("Fire1"))
        {
            if (Powers.Count > 0)
            {
                Powers[0].GetComponent<Activatable>().Activate(gameObject);
            }
        }
    }

    /// <summary>
    /// Method to move the player by 
    /// leveraging the character controller move method
    /// </summary>
    protected virtual void Move()
    {
        /*
        if (isSprinting)
            gameObject.transform.Translate(new Vector3(movingRight + (movingRight * SprintSpeed), movingUp + (movingUp * SprintSpeed), 0) * Time.deltaTime);
        else
            gameObject.transform.Translate(new Vector3(movingRight, movingUp, 0) * Time.deltaTime);
            */
        float yMovement = movingUp * MovementSpeed * Time.deltaTime;
        float xMovement = movingRight * MovementSpeed * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + xMovement, gameObject.transform.position.y + yMovement, 0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CanTarget = true;
        canMove = false;
    }

    public virtual void onDeath()
    {
        gameObject.transform.position = StartPos.position;
        TargetLocation = StartPos.position;
    }

    IEnumerator ProtectMovement()
    {
        while(true)
        {
            if(canMove)
                
                yield return new WaitForSeconds(5f);
            
        }
    }

    public bool countMovement()
    {
        movementCount++;
        return true;
    }
}
