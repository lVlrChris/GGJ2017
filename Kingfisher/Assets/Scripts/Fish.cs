﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public Vector3 OriginPoint;
    public bool IsScared = false;
    public bool AtOrigin = false;
    public float ScaredCooldown = 10.0f;
    private float LilyCooldown = 4.0f;

    public DateTime LastScared;
    public bool Following = false;

    public bool AtLily = false;
    public float Stamina = 100;

    public bool ignorePlayer = false;

    public Vector3 lilyPosition;

    public int speed = 1;


    public bool isIdling = true;

    private Vector3 v;



    // Use this for initialization
    void Start ()
	{
        Vector3 empty = new Vector3(0,0,0);
	    if (OriginPoint == empty)
	    {
            Debug.Log("Geen beginpositie");
            OriginPoint = transform.position;

        }
        v = transform.position - new Vector3(transform.position.x + 0.5f, transform.position.y , transform.position.z +0.5f);

    }

    void CheckSonar()
    {
        if (Input.GetKeyUp(("space")))
        {
            Following = false;
        }

    }

    void CheckIfScared()
    {
        if (IsScared && !ignorePlayer)
        {


            if (gameObject.transform.position.x < 3.5 && gameObject.transform.position.z < 1.8 && gameObject.transform.position.x >  -3.50 && gameObject.transform.position.z > -2.01)
            {
                var forward = Vector3.forward;
                //forward.y = 0.82f;
                gameObject.transform.Translate(forward * Time.deltaTime);
                gameObject.transform.position =
                    (new Vector3(gameObject.transform.position.x, 0.82f, gameObject.transform.position.z));
            }
            Stamina -= 0.01f;
         //   GameObject.FindGameObjectWithTag("Stamina").GetComponent<Text>().text = "Stamina " + Stamina;
            ScaredCooldown = 10;
            AtOrigin = false;
        }
    }

    void CheckCooldown(float timer)
    {
        
    }

    void CheckIfFollowing()
    {
        if (Following && !ignorePlayer)
        {
            IsScared = false;
            Debug.Log(("VOLGEN"));
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            transform.transform.LookAt(player.transform);

            gameObject.transform.position =
    (new Vector3(gameObject.transform.position.x, 0.82f, gameObject.transform.position.z));

            //var distance = Vector3.Distance(transform.position, player.GetComponent<Renderer>().bounds.center);

            /* if (distance > 10)
             {
                 Debug.Log("het ken");
                 transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                     speed * Time.deltaTime / 10);

             }*/
        }
    }

	// Update is called once per frame
	void Update ()
	{
        //transform.Rotate(0, transform.rotation.y, 0); //bijna goed
        
        
        //transform.rotation = Quaternion.identity;

        //Debug.Log(distance);
        /* if (distance <= 4)
         {
             gameObject.transform.LookAt(gameObject.transform);
             gameObject.transform.Rotate(0, 180, 0);
             gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
         }
         */
        DateTime currentDate = DateTime.Now;



        long elapsedLilyTicks = currentDate.Ticks - LastScared.Ticks;
        TimeSpan elapsedLilySpan = new TimeSpan(elapsedLilyTicks);

        if (elapsedLilySpan.TotalSeconds >= LilyCooldown)
        {

            AtLily = false;
            ignorePlayer = false;
        }



        CheckSonar();


        //als vis niet bang is ga na 10 sec terug naar beginpunt
        long elapsedTicks = currentDate.Ticks - LastScared.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
	    if (elapsedSpan.TotalSeconds >= ScaredCooldown)
	    {
	        IsScared = false;
          //  gameObject.transform.LookAt(OriginPoint);
        //    transform.position = Vector3.MoveTowards(transform.position, OriginPoint, speed * Time.deltaTime);

        }


	    Idle();

        if (Stamina > 100) Stamina = 100;

        CheckIfScared();

        CheckIfFollowing();

	    if (gameObject.transform.position == OriginPoint)
	    {
	        isIdling = true;
	    }
	    //   AtOrigin = true;
        // }
        //	    if (AtOrigin)
        //  {
        //       // transform.Rotate((new Vector3(0, 2, 0) * 2 * Time.deltaTime));
        // transform.Translate(Vector3.forward * 1 * Time.deltaTime);
        // }
        if (AtLily)
        {
            Debug.Log("PLS DOE HET NOUUU");
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
           // Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
            speed = 0;
            transform.Translate(lilyPosition);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("HALLO");
        }

    }

    void Idle()
    {
        if (isIdling)
        {
            Debug.Log("idle nou");
            v = Quaternion.AngleAxis(20 * Time.deltaTime, Vector3.up) * v;
            transform.Rotate(Vector3.up * Time.deltaTime * 20);
            transform.position = OriginPoint + v;
        }
    }
}
