using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_PowerUp : Interactable
{
    //public int NumberLives = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement_AnimationTest>().NumLives;
    public GameObject ring;
    public int NumberLives;

    public override void Interact()
    {
        NumberLives += 1;

        ring.SetActive(false);

        Invoke("Reset", 0.001f);

    }

    private void Reset()
    {
        if (NumberLives > 0)
        {
            NumberLives = 0;
        }

    }
}
