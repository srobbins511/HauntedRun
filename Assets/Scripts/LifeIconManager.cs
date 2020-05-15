using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIconManager : MonoBehaviour
{
    public GameObject PlayerIconPrefab;
    public List<GameObject> Icons;
    GameObject temp;
    public GameObject P;

    public Coroutine startLoading;

    public int NumLives;

    public int prevLifeCount;

    public bool run;

    public void Start()
    {
        run = false;
        Invoke("Run", 1f);
    }

    public void Update()
    {
        if (run)
        {
            if (GameManager.Instance.numLives < prevLifeCount)
            {
                OnDeath();
            }
            if (GameManager.Instance.numLives > prevLifeCount)
            {
                OnLifeGain();
            }
        }

    }
    public void Run()
    {
        run = true;
        P = GameObject.FindGameObjectWithTag("Player");
        Icons = new List<GameObject>();
        NumLives = GameManager.Instance.numLives;
        prevLifeCount = NumLives;

        for (int i = 0; i < NumLives; ++i)
        {
            temp = Canvas.Instantiate(PlayerIconPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            temp.transform.localPosition += new Vector3(-i * 50, 0);
            Icons.Add(temp);
        }

    }


    public void OnDeath()
    {
        Icons[--prevLifeCount].GetComponent<Image>().color = new Color(Icons[prevLifeCount].GetComponent<Image>().color.r, Icons[prevLifeCount].GetComponent<Image>().color.g, Icons[prevLifeCount].GetComponent<Image>().color.b, .3f);
    }

    public void OnLifeGain()
    {
        Debug.Log("Run Called");
        if (NumLives == prevLifeCount)
        {
            temp = Canvas.Instantiate(PlayerIconPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            temp.transform.localPosition += new Vector3(Icons[prevLifeCount-1].transform.localPosition.x - 50, 0);
            Icons.Add(temp);
            NumLives++;
            prevLifeCount++;
        }
        else
        {
            Icons[prevLifeCount].GetComponent<Image>().color = new Color(Icons[prevLifeCount].GetComponent<Image>().color.r, Icons[prevLifeCount].GetComponent<Image>().color.g, Icons[prevLifeCount].GetComponent<Image>().color.b, 1f);
            prevLifeCount++;
        }
    }
}
