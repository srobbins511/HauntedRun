using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAudio : MonoBehaviour
{
    public AudioSource audioSource;
    AudioClip audioClip;

    // Start is called before the first frame update
    public void Play()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
        Debug.Log("lever sound");
    }

}
