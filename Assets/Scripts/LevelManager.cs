using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Keys;


    [SerializeField]
    private string NextLevel;

    private int keyIndex = 0;

    private int KeyMax;


    public void Start()
    {
        KeyMax = Keys.Count;
    }

    public void OnKeyCollect()
    {
        Debug.Log("On Key Collect");
        keyIndex++;
    }


    public void OnComplete()
    {
        if(CheckKeys())
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
    private bool CheckKeys()
    {
        return keyIndex >= KeyMax;
    }
}
