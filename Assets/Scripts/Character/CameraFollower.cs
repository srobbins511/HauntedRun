using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform playerLocation;
    public int MinSize;
    public int MaxSize;

    private float size;


    public void Start()
    {
        gameObject.GetComponent<Camera>().orthographic = true;
        size = gameObject.GetComponent<Camera>().orthographicSize;
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Mathf.Lerp(gameObject.transform.position.x, playerLocation.position.x, .1f), Mathf.Lerp(gameObject.transform.position.y, playerLocation.position.y, .1f), gameObject.transform.position.z);
        ReSizeCamera();
    }

    private void ReSizeCamera()
    {
        if (size < MaxSize && size > MinSize)
        {
            size = gameObject.GetComponent<Camera>().orthographicSize -= 10 * Input.GetAxis("Mouse ScrollWheel");
        }
        else if (size > MaxSize && Input.GetAxis("Mouse ScrollWheel")>0)
        {
            size = gameObject.GetComponent<Camera>().orthographicSize -= 10 * Input.GetAxis("Mouse ScrollWheel");
        }
        else if(size < MinSize && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            size = gameObject.GetComponent<Camera>().orthographicSize -= 10 * Input.GetAxis("Mouse ScrollWheel");
        }
    }

    public void FindPlayer()
    {
        
    }
}
