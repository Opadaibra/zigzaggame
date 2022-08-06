using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{

    private Transform Player;
    [SerializeField] private float smoothspeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        GameObject tempplayerref = GameObject.FindWithTag("Player");
        Player = tempplayerref.transform;
    }
    private void FixedUpdate()
    {

        Vector3 desiredpos = Player.transform.position + offset;
        Vector3 smoothpos = Vector3.Lerp(transform.position, desiredpos, smoothspeed);
        transform.position = smoothpos;
        
        
    }

}