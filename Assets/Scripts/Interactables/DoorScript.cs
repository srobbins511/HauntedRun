using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public Animator animator1;
    public Animator animator2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        animator1.SetTrigger("IsOpen");
        animator2.SetTrigger("IsOpen2");
    }
}
