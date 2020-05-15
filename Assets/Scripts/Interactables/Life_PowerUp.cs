using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_PowerUp : MonoBehaviour
{
    public int NumberLives;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Added a Life!");

            GameManager.Instance.numLives += 1;

            Destroy(this.gameObject);
        }
    }
}
