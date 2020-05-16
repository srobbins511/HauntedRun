using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public Text NumLives;

    public GameObject UITextInterface;

    public GameObject PauseScreen;

    public Image BlackScreen;

    Coroutine DarkenScreen;

    // Start is called before the first frame update
    void Start()
    {
        BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
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
        GameManager.Instance.Pause();
    }

    public void FadeOutScreen()
    {
        Debug.Log("DarkenScreen");
        DarkenScreen = StartCoroutine(Darken());
    }

    public void FadeInScreen()
    {
        DarkenScreen = StartCoroutine(Brighten());
    }

    IEnumerator Darken()
    {
        BlackScreen.enabled = true;
        while(BlackScreen.color.a < .9f)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, Mathf.Lerp(BlackScreen.color.a, 1f, Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Darkened Completely");
        BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, 1f);
        GameManager.Instance.resetPlayer();

    }

    IEnumerator Brighten()
    {
        Debug.Log("Brighten");
        while (BlackScreen.color.a > .1f)
        {
            BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, Mathf.Lerp(BlackScreen.color.a, 0f, Time.deltaTime));
            GameManager.Instance.Player.GetComponent<CharacterMovement_AnimationTest>().dying = false;
            yield return new WaitForEndOfFrame();
        }
        BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, 0f);

    }
}
