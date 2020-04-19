using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int numLives;
    public GameObject Player;

    public string endLevel;
    public static GameManager Instance;

    public ContactFilter2D BlockViewFilter;

    public Coroutine gameTimer;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TriggerDeath()
    {
        numLives--;
        if (numLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Reset Movement called");
            Player.GetComponent<CharacterMovement>().onDeath();
        }
    }

    public void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
    //
    public void TriggerVictory()
    {
        //Some Mechanic needed to show victory
    }

    public bool GameTimer(GameObject callingObject, float timeMax)
    {
        gameTimer = StartCoroutine(Timer(callingObject, timeMax));
        return true;
    }

    
    IEnumerator Timer(GameObject callingObject, float timeMax)
    {
        float time = 0;
        while(time < timeMax)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public bool TimerEnd(GameObject callingObject)
    {
        return true;
    }
}
