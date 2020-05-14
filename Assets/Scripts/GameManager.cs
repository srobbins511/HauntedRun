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

    public GameObject Ring;

    public string endLevel;
    public static GameManager Instance;

    public ContactFilter2D BlockViewFilter;

    public ContactFilter2D BlockMovementFilter;

    public Coroutine gameTimer;

    public EnemyManager enemyManager;

    public GameObject HUD;

    public Camera MainCamera;

    public int LevelCount = 0;

    public bool Paused = false;

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
        Ring = GameObject.Find("RingPowerUp");
        if(Player != null)
            numLives = Player.GetComponent<CharacterMovement>().NumLives;
        enemyManager = FindObjectOfType<EnemyManager>();
        HUD = GameObject.FindGameObjectWithTag("HUD");

    }

    public void TriggerDeath()
    {
        if (!Player.GetComponent<CharacterMovement_AnimationTest>().dying)
        {
            numLives--;
            Player.GetComponent<CharacterMovement_AnimationTest>().Killed();
        }
    }

    public void BlackScreen()
    {
        HUD.GetComponent<HUDManager>().FadeOutScreen();
    }

    public void Respawn()
    {
        foreach (GhostActivationManager g in FindObjectsOfType<GhostActivationManager>())
        {
            g.Reset();
        }
        enemyManager.resetGhostStates();
        if (numLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            Debug.Log("Reset Movement called");
            HUD.GetComponent<HUDManager>().FadeInScreen();
        }
    }

    public void resetPlayer()
    {
        Player.GetComponent<CharacterMovement_AnimationTest>().onDeath();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        if((SceneManager.GetActiveScene().name.Equals("WinScreen") || SceneManager.GetActiveScene().name.Equals("GameOver")) && Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene(0);
        }

        //ring power up test
        if (Ring.GetComponent<Life_PowerUp>().NumberLives == 1)
        {
            numLives += 1;
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
        numLives = Player.GetComponent<CharacterMovement>().NumLives;
    }

    public void Pause()
    {
        Paused = !Paused;
    }


    public void Instatiate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyManager = FindObjectOfType<EnemyManager>();
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }
}
