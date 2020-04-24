using System.Collections;
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

    public bool MultiplePages;

    private const float loadTime = 1f;

    public bool FinalPage;
    void Start()
    {
        Text.GetComponent<TextMeshProUGUI>().SetText("");
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        Backlog = new List<UITextObj>();
        MultiplePages = false;
        FinalPage = false;
    }

    public void Update()
    {
        if(MultiplePages)
        {
            if(Input.GetButtonDown("Interact"))
            {
                Debug.Log("Switch Called");
                SwitchPage();
            }
        }
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
            Debug.Log(CheckBacklog(temp));
            if(!CheckBacklog(temp))
                Backlog.Add(new UITextObj(textGiven, time, textWriteSpeed));
        }
    }

    public bool CheckBacklog(UITextObj temp)
    {
        //Debug.Log(Backlog.Count);
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

    public void SwitchPage()
    {
        Text.GetComponent<TextMeshProUGUI>().pageToDisplay = ++Text.GetComponent<TextMeshProUGUI>().pageToDisplay;
        if (Text.GetComponent<TextMeshProUGUI>().textInfo.pageCount == Text.GetComponent<TextMeshProUGUI>().pageToDisplay)
            FinalPage = true;
    }

    IEnumerator Timer(string tempTextGiven, float tempTimeGiven, uint tempTextWriteSpeed)
    {
        UITextObj temp;
        string textGiven = tempTextGiven;
        float timeGiven = tempTimeGiven;
        uint textWriteSpeed = tempTextWriteSpeed;
        string tempText = "";
        bool loop = false;

        float time = 0f;
        while (time < loadTime)
        {
            time += Time.deltaTime;
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, Mathf.Lerp(backgroundImage.color.a, .5f, Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }

        do
        {
            loop = false;
            time = 0f;
            tempText = Text.GetComponent<TextMeshProUGUI>().text;
            foreach (char c in textGiven)
            {
                tempText += c.ToString();
                Text.GetComponent<TextMeshProUGUI>().SetText(tempText);
                for (int i = 0; i <= textWriteSpeed; i++)
                {
                    if (Text.GetComponent<TextMeshProUGUI>().textInfo.pageCount > 1)
                    {
                        MultiplePages = true;
                    }
                    yield return new WaitForEndOfFrame();
                }
                    
            }

            if(MultiplePages)
            {
                while(!FinalPage)
                {
                    yield return new WaitForEndOfFrame();
                }
            }

            
            while (time < timeGiven)
            {
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Debug.Log(Backlog.Count);
            if(Backlog.Count > 0)
            {
                loop = true;
                Debug.Log("Enetered");
                temp = Backlog[0];
                Backlog.RemoveAt(0);
                textGiven = temp.text;
                timeGiven = temp.time;
                textWriteSpeed = temp.textWriteSpeed;
                tempText = "";
                Text.GetComponent<TextMeshProUGUI>().SetText("");
                MultiplePages = false;
                Text.GetComponent<TextMeshProUGUI>().pageToDisplay = 1;
                FinalPage = false;
            }

        } while (loop);
        Deactivate();
    }
    
}
