﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Movement : MonoBehaviour {
    private Rigidbody2D RigiB2d;
    private Rigidbody2D CollidedPlayerRG2D;
    private float PMaxSpeed = 100;
    private float PCurrVeloX;
    private float PCurrVeloY;
    public bool InputEnabled = true;
    private int PushStunCont = 100;
    public bool PlayerColl = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {

        }
        if (collision.gameObject.tag == "Table Leg")
        {

        }
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player")
        {
            InputEnabled = false;
        }
            if (PlayerColl == false)
        {
            if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player")
            {
                switch(collision.gameObject.tag)
                {
                    case "Player2":
                        collision.gameObject.GetComponent<Player2Movement>().PlayerColl = true;
                        break;
                    case "Player":
                        collision.gameObject.GetComponent<Player1Movement1>().PlayerColl = true;
                        break;
                    case "Player3":
                        collision.gameObject.GetComponent<Player3Movment>().PlayerColl = true;
                        break;
                    default:
                        break;
                }
                CollidedPlayerRG2D = collision.gameObject.GetComponent<Rigidbody2D>();
                PMaxSpeed = 200;
                RigiB2d.velocity = new Vector2(CollidedPlayerRG2D.velocity.x * 2, CollidedPlayerRG2D.velocity.y * 2);
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        RigiB2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (InputEnabled == false)
        {
            PushStunCont--;
            if (PushStunCont == 0)
            {
                PlayerColl = false;
                InputEnabled = true;
                PushStunCont = 100;
                PMaxSpeed = 100;
                CollidedPlayerRG2D = null;
            }
        }
        PCurrVeloX = RigiB2d.velocity.x * 100;
        PCurrVeloY = RigiB2d.velocity.y * 100;
        if (InputEnabled == true)
        {
            if (Input.GetButton("Left P4"))
            {
                RigiB2d.velocity = new Vector2(-PMaxSpeed, 0);
            }
            if (Input.GetButton("Right P4"))
            {
                RigiB2d.velocity = new Vector2(PMaxSpeed, 0);
            }
            if (Input.GetButton("Up P4"))
            {
                RigiB2d.velocity = new Vector2(0, PMaxSpeed);
            }
            if (Input.GetButton("Down P4"))
            {
                RigiB2d.velocity = new Vector2(0, -PMaxSpeed);
            }
            if (Input.GetButton("Left P4") == false && Input.GetButton("Right P4") == false
                && Input.GetButton("Up P4") == false && Input.GetButton("Down P4") == false && InputEnabled == true)
            {
                RigiB2d.velocity = new Vector2(0, 0);
            }
        }
    }
}
