using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSphereController : MonoBehaviour
{

    public float startScale;
    public float endScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Update()
    {
        if( !(gameObject.transform.localScale.x >= 9))
        {
            gameObject.transform.localScale = new Vector3(Mathf.Lerp(gameObject.transform.localScale.x, endScale, .1f), Mathf.Lerp(gameObject.transform.localScale.y, endScale, .1f), 0f );
        }
        else
        {
            gameObject.transform.localScale = new Vector3(Mathf.Lerp(gameObject.transform.localScale.x, startScale, .1f), Mathf.Lerp(gameObject.transform.localScale.y, startScale, .1f), 0f);
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
