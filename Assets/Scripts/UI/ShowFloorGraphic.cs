using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;


public class ShowFloorGraphic : MonoBehaviour {

    public GameObject floorgraphic;
    public GameObject floormanager;
    PlayerController PlayerController;
    ThirdPersonCamera ThirdPersonCamera;

    public AudioSource source;
    public AudioClip land;

    private bool landed;

    private void Start()
    {
        ThirdPersonCamera = GameObject.Find("Main Camera").GetComponent<ThirdPersonCamera>();
        PlayerController = GetComponent<PlayerController>();
        landed = false;
    }

    private void Update()
    {
        if (!landed)
        {
            PlayerController.speed = 0f;
        }
        else
        {
            PlayerController.speed = 5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == floormanager)
        {
            ThirdPersonCamera.startShake = true;
            source.clip = land;
            source.Play();
            landed = true;
            floorgraphic.SetActive(true);
            Destroy(other);
        }
        
    }
}
