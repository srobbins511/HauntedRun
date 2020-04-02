using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float movingUp;
    public float movingLeft;
    public Transform currentPos;
    public bool moved;
    public bool isSprinting;

    private CharacterController c;

    [SerializeField]
    private float MovementSpeed;

    [SerializeField]
    [Tooltip("Increases movement speed by percentage, should be  value between 0 and 1")]
    private float SprintSpeed;

    // Start is called before the first frame update
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

    private bool checkInputs()
    {
        Debug.Log("CheckInputs Called");
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

    private void Move()
    {
        Debug.Log("MoveCalled");
        if (isSprinting)
            c.Move(new Vector3(movingLeft + (movingLeft * SprintSpeed), movingUp + (movingUp * SprintSpeed), 0) * Time.deltaTime);
        else
            c.Move(new Vector3(movingLeft, movingUp, 0) * Time.deltaTime);
    }
}
