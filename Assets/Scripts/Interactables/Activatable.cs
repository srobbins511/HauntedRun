using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : Interactable
{
    // Start is called before the first frame update
    public abstract void Activate(GameObject Player);
}
