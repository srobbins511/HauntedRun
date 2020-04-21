﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITextInterfaceController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Text;

    public Image backgroundImage;

    public Coroutine LoadTimer;

    public List<UITextObj> Backlog;

    private const float loadTime = 1f;
    void Start()
    {
        Text.GetComponent<TextMeshProUGUI>().SetText("");
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        Backlog = new List<UITextObj>();
    }

    public void WriteToScreen(string textGiven, float time, uint textWriteSpeed)
    {
        if (LoadTimer == null)
        {
            LoadTimer = StartCoroutine(Timer(textGiven, time, textWriteSpeed));
        }
        else
        {
            UITextObj temp = new UITextObj(textGiven, time, textWriteSpeed);
            if(!CheckBacklog(temp))
                Backlog.Add(temp);
        }
    }

    public bool CheckBacklog(UITextObj temp)
    {
        if(Backlog.Count == 0)
        {
            return false;
        }
        foreach(UITextObj t in Backlog)
        {
            if(t.Equals(temp))
            {
                return true;
            }
        }
        return false;
    }

    public void Deactivate()
    {
        Text.GetComponent<TextMeshProUGUI>().SetText("");
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        StopCoroutine(LoadTimer);
        LoadTimer = null;
    }

    IEnumerator Timer(string tempTextGiven, float tempTimeGiven, uint tempTextWriteSpeed)
    {
        string textGiven = tempTextGiven;
        float timeGiven = tempTimeGiven;
        uint textWriteSpeed = tempTextWriteSpeed;
        string tempText = "";

        float time = 0f;
        while (time < loadTime)
        {
            time += Time.deltaTime;
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, Mathf.Lerp(backgroundImage.color.a, .5f, Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }

        do
        {
            
            time = 0f;
            tempText = Text.GetComponent<TextMeshProUGUI>().text;
            foreach (char c in textGiven)
            {
                tempText += c.ToString();
                Text.GetComponent<TextMeshProUGUI>().SetText(tempText);
                for (int i = 0; i <= textWriteSpeed; i++)
                    yield return new WaitForEndOfFrame();
            }

            while (time < timeGiven)
            {
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            if(Backlog.Count != 0)
            {
                UITextObj temp = Backlog[0];
                Backlog.RemoveAt(0);
                textGiven = temp.text;
                timeGiven = temp.time;
                textWriteSpeed = temp.textWriteSpeed;
                tempText = "";
                Text.GetComponent<TextMeshProUGUI>().SetText("");
            }

        } while (Backlog.Count != 0);
        Deactivate();
    }
    
}
