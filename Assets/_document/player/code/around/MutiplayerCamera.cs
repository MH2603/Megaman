using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class MutiplayerCamera : MonoBehaviour
{
    public GameObject[] players;

    public Vector3 offset;

    public float smoothTime = 0.5f;
    Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (players.Length  < 2)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

        Move();
        Zoom();
        
      
    }

    void Zoom() 
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetDistance()/ zoomLimiter);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    
    }

    float GetDistance()
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);

        for (int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        return bounds.size.x;
    }


    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

    }

    Vector3 GetCenterPoint()
    {
        if (players.Length == 1) return players[0].transform.position;


        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        for ( int i = 0;i < players.Length ;i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        return bounds.center;   
    }
}
