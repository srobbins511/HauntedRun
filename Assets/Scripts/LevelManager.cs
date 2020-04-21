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


    public void LateStart()
    {
        KeyMax = Keys.Count;
        GameManager.Instance.Instatiate();
    }

    public void OnKeyCollect()
    {
        Debug.Log("On Key Collect");
        keyIndex++;
    }


    public void OnComplete()
    {
        Debug.Log("Called");
        if(CheckKeys())
        {
            GameManager.Instance.LoadLevel(NextLevel);
        }
    }
    public bool CheckKeys()
    {
        return keyIndex >= KeyMax;
    }
}
