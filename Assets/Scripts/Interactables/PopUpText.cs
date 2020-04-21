using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : Interactable
{
    public string text;

    public float TimeShown;

    public uint textWriteSpeed;

    public Coroutine timer;


    public override void Interact()
    {
        GameManager.Instance.WriteToPlayer(text, TimeShown, textWriteSpeed);
        timer = StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(TimeShown);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
