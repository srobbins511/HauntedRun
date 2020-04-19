using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Activatable
{
    // Start is called before the first frame update

    public void Start()
    {
        gameObject.tag = "Interactable";
    }
    public override void Activate(GameObject Player)
    {
        Player.GetComponent<CharacterMovement>().Powers.Remove(gameObject);
        GameObject.Destroy(gameObject);
        Debug.Log("Activated");
    }

    public override void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
