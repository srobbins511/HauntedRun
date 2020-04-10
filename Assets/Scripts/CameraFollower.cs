using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerLocation;


    public void Start()
    {
        playerLocation = GameManager.Instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = new Vector3(Mathf.Lerp(gameObject.transform.position.x, playerLocation.position.x, .1f), Mathf.Lerp(gameObject.transform.position.y, playerLocation.position.y, .1f), gameObject.transform.position.z);
    }
}
