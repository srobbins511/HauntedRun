﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverScript : Interactable
{
    [SerializeField]
    private GameObject controlledObject;

    [SerializeField]
    private Canvas eventText;

    private float timer;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(eventText != null)
            eventText.enabled = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(eventText != null && eventText.enabled && timer < 5f)
        {
            timer += Time.deltaTime;
        }
        else if(eventText != null)
        {
            eventText.enabled = false;
        }
    }

    public override void Interact()
    {
        animator.SetTrigger("IsTriggered");

        if (controlledObject.tag.Equals("LeverControlled"))
        {
            controlledObject.GetComponent<Interactable>().Interact();
            if(eventText != null)
                eventText.enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
