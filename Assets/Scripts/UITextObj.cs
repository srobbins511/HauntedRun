using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextObj : MonoBehaviour
{
    public string text;
    public float time;
    public uint textWriteSpeed;

    public UITextObj(string text, float time, uint textWriteSpeed)
    {
        this.text = text;
        this.time = time;
        this.textWriteSpeed = textWriteSpeed;
    }

    public bool Equals(UITextObj other)
    {
        return (this.text.Equals(other.text) && this.time == other.time && this.textWriteSpeed == other.textWriteSpeed);
    }
}
