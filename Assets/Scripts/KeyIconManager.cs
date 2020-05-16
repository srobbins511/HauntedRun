using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class KeyIconManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject KeyIconPrefab;
    public List<GameObject> Icons;
    GameObject temp;
    private GameObject LM;

    public Coroutine startLoading;

    public int NumKeysInLevel;

    public int prevKeyIndex;

    private bool run;
    public void Start()
    {
        run = false;
        prevKeyIndex = 0;
        Invoke("Run", 1f);
    }

    public void Update()
    {
        if (run)
        {
            if (LM.GetComponent<LevelManager>().keyIndex > prevKeyIndex)
            {
                OnKeyCollect();
            }
        }   
    }
    public void Run()
    {
        run = true;
        LM = GameObject.FindGameObjectWithTag("LevelManager");
        Icons = new List<GameObject>();
        NumKeysInLevel = LM.GetComponent<LevelManager>().KeyMax;
        for (int i = 0; i < NumKeysInLevel; ++i)
        {
            temp = Canvas.Instantiate(KeyIconPrefab,gameObject.transform.position,gameObject.transform.rotation, gameObject.transform);
            temp.transform.localPosition += new Vector3(i * 50, 0);
            Icons.Add(temp);
        }

    }


    public void OnKeyCollect()
    {
        Icons[prevKeyIndex].GetComponent<Image>().color = new Color(Icons[prevKeyIndex].GetComponent<Image>().color.r, Icons[prevKeyIndex].GetComponent<Image>().color.g, Icons[prevKeyIndex].GetComponent<Image>().color.b,1f);
        prevKeyIndex++;
    }

}
