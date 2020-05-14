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

            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().NumLives += 1;

            Destroy(this.gameObject);
        }
    }
}
