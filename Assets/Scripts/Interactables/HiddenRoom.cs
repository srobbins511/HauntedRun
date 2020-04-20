using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : Interactable
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject Entrance;

    [SerializeField]
    private GameObject Room;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        Entrance.SetActive(false);
        Room.SetActive(true);
        GameManager.Instance.enemyManager.FindGhosts();
    }
}
