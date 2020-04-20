using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : Interactable
{
    public string text;

    public float TimeShown;

    public uint textWriteSpeed;


    public override void Interact()
    {
        GameManager.Instance.WriteToPlayer(text, TimeShown, textWriteSpeed);
    }
}
