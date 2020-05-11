using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDoorScript : Interactable
{
    public override void Interact()
    {
        List<DoorScript> doors = new List<DoorScript>(GetComponentsInChildren<DoorScript>());
        foreach(DoorScript d in doors)
        {
            d.Interact();
        }
    }
}
