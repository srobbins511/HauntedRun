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
            Player.transform.position = Player.GetComponent<CharacterMovement>().StartPos.position;
        }
    }

    public void TriggerVictory()
    {
        //Some Mechanic needed to show victory
    }

    public void Update()
    {
        if(Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }
}
