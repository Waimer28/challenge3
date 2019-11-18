﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private Game_Controller gameController; 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundary") ||other.CompareTag ("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")

        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.Gameover();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
       gameController.AddScore(scoreValue);
    }
     void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Game_Controller>();
        }  
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
}