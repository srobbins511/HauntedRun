using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoomKeysScript : MonoBehaviour
{
    public List<GameObject> hiddenKeys;

    public void Start()
    {
        foreach(GameObject k in hiddenKeys)
        {
            if(k.CompareTag("Collectable"))
            {
                GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().AddKey(k);
            }
        }
    }
}
