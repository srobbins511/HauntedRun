using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int numLives;
    public GameObject Player;

    public string endLevel;
    public static GameManager Instance;

    public ContactFilter2D BlockViewFilter;

    public ContactFilter2D BlockMovementFilter;

    public Coroutine gameTimer;

    public EnemyManager enemyManager;

    public GameObject HUD;

    public Camera MainCamera;

    public int LevelCount = 0;

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
        if(Player != null)
            numLives = Player.GetComponent<CharacterMovement>().NumLives;
        enemyManager = FindObjectOfType<EnemyManager>();
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }

    public void TriggerDeath()
    {
        numLives--;
        foreach(GhostActivationManager g in FindObjectsOfType<GhostActivationManager>())
        {
            g.Reset();
        }
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
        if(SceneManager.GetActiveScene().buildIndex >= 3 && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene(0);
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

    public void WriteToPlayer(string text, float time, uint textWriteSpeed)
    {
        HUD.GetComponent<HUDManager>().WriteTextToPlayer(text, time, textWriteSpeed);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Startgame()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.Awake();
        LevelCount++;
    }

    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

    

    public void Instatiate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyManager = FindObjectOfType<EnemyManager>();
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }
}
