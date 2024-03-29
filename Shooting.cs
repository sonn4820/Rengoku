﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; // create fire point for prefab
    public GameObject arrowPrefab;  // place to drop prefab
    public int maxArrow= 60; // limit the number of arrows can be used
    public int numArrows = 0; // initialize arrow counter starts at 0
    public AudioSource shoot; // place for drop audio
    public float timeBetweenShots = 0.4f;  // time between each shot
    private float delaytime; // call delay time
    public Text numAr; // place for text
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 5f); // invoke the shoot function
        shoot = GetComponent<AudioSource>(); // get the audio source 
        
}

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= delaytime && (Input.GetKeyDown(KeyCode.J))) // Use J to shoot
        {
            Shoot(); // activate the shoot function
            numArrows++;  // every time a ball is created, increment number in var
            delaytime = Time.time + timeBetweenShots; // delay time = timebtwshots
        }
        if (numArrows > maxArrow) // arrow running out if the player overused it
        {
            Destroy(gameObject);
        } else
        {
            numAr.text = "Arrows used:"+ numArrows +"/60"; // show the number of arrows are used
        }
     
    }
    void Shoot() // shoot function
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation); // instantiate the arrows

        shoot.Play(); // play the audios
    }
}
    
        

