using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public void Quit()
    {
        GameManager.Instance.Quit();
    }

    public void Startgame()
    {
        GameManager.Instance.Startgame();
    }
}
