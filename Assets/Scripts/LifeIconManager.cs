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

    public void Start()
    {
        Invoke("Run", 1f);
    }

    public void Update()
    {

        if (GameManager.Instance.numLives < prevLifeCount)
        {
            OnDeath();
        }

    }
    public void Run()
    {
        P = GameObject.FindGameObjectWithTag("Player");
        Icons = new List<GameObject>();
        NumLives = GameManager.Instance.numLives;
        for (int i = 0; i < NumLives; ++i)
        {
            temp = Canvas.Instantiate(PlayerIconPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            temp.transform.localPosition += new Vector3(i * 50, 0);
            Icons.Add(temp);
        }

    }


    public void OnDeath()
    {
        Icons[prevLifeCount].GetComponent<Image>().color = new Color(Icons[prevLifeCount].GetComponent<Image>().color.r, Icons[prevLifeCount].GetComponent<Image>().color.g, Icons[prevLifeCount].GetComponent<Image>().color.b, .3f);
        prevLifeCount++;
    }
}
