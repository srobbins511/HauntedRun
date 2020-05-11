using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorListener : MonoBehaviour
{
    // Start is called before the first frame update
    public void Opened()
    {
        GetComponentInParent<DoorScript>().Opened();
    }
}
