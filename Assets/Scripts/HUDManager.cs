using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public Text NumLives;

    public GameObject UITextInterface;

    public GameObject PauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NumLives.text = "Life Count: " + GameManager.Instance.numLives;
        if(Input.GetKeyDown(KeyCode.M))
        {
            GameManager.Instance.Pause();
            Pause();
        }
    }

    public void WriteTextToPlayer(string text, float time, uint textWriteSpeed)
    {
        UITextInterface.GetComponent<UITextInterfaceController>().WriteToScreen(text, time, textWriteSpeed);
    }

    public void Pause()
    {
        UITextInterface.SetActive(!UITextInterface.activeInHierarchy);
        PauseScreen.SetActive(!PauseScreen.activeInHierarchy);
    }
}
