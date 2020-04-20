using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : DoorScript
{
    public override void Interact()
    {
        if (FindObjectOfType<LevelManager>().CheckKeys())
            base.Interact();
    }
}
