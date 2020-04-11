using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : Interactable
{
    [SerializeField]
    private GameObject controlledObject;
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
        if(controlledObject.tag.Equals("LeverControlled"))
        {
            controlledObject.GetComponent<Interactable>().Interact();
        }
    }
}
