using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSphereController : MonoBehaviour
{

    public float startScale;
    public float endScale;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    public void Update()
    {
        if(isActive)
        {
            //isActive = false;
        }
        else if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Interactable"))
        {
            collision.GetComponent<Interactable>().Interact();
        }
    }
}
