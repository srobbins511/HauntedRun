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

    private const float loadTime = 1f;
    void Start()
    {
        Text.GetComponent<TextMeshProUGUI>().SetText("");
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
    }

    public void WriteToScreen(string textGiven, float time, uint textWriteSpeed)
    {
        if (LoadTimer == null)
        {
            LoadTimer = StartCoroutine(Timer(textGiven, time, textWriteSpeed));
        }
    }

    public void Deactivate()
    {
        Text.GetComponent<TextMeshProUGUI>().SetText("");
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        StopCoroutine(LoadTimer);
        LoadTimer = null;
    }

    IEnumerator Timer(string textGiven, float timeGiven, uint textWriteSpeed)
    {
        float time = 0f;
        while (time < loadTime)
        {
            time += Time.deltaTime;
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, Mathf.Lerp(backgroundImage.color.a,.5f, Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
        time = 0f;
        string tempText = Text.GetComponent<TextMeshProUGUI>().text;
        foreach (char c in textGiven)
        {
            tempText += c.ToString();
            Text.GetComponent<TextMeshProUGUI>().SetText(tempText);
            for(int i = 0; i <= textWriteSpeed; i++)
                yield return new WaitForEndOfFrame();
        }

        while(time < timeGiven)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Deactivate();
    }
    
}
