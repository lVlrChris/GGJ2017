using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class Fish : MonoBehaviour
{
    public Vector3 OriginPoint;
    public bool IsScared = false;
    public bool AtOrigin = false;
    public float ScaredCooldown = 10.0f;
    public DateTime LastScared;
    public bool Following = false;

    public float Stamina = 100;


    // Use this for initialization
    void Start ()
	{
        Vector3 empty = new Vector3(0,0,0);
	    if (OriginPoint == empty)
	    {
            Debug.Log("Geen beginpositie");
            OriginPoint = transform.position;

        }

    }
	
	// Update is called once per frame
	void Update ()
	{
        //Debug.Log(distance);
        /* if (distance <= 4)
         {
             gameObject.transform.LookAt(gameObject.transform);
             gameObject.transform.Rotate(0, 180, 0);
             gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
         }
         */

        if (XCI.GetButtonUp(XboxButton.RightBumper) || Input.GetKeyUp(("space")))
        {
            Following = false;
        }



        //als vis niet bang is ga na 10 sec terug naar beginpunt
        DateTime currentDate = DateTime.Now;
        long elapsedTicks = currentDate.Ticks - LastScared.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
	    if (elapsedSpan.TotalSeconds >= ScaredCooldown)
	    {
	        IsScared = false;
            gameObject.transform.LookAt(OriginPoint);

        }




        if (Stamina > 100) Stamina = 100;

	    if (IsScared)
	    {


            if (gameObject.transform.position.x < 3.5 && gameObject.transform.position.z < 2.6)
            {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            Stamina -= 0.01f;
            GameObject.FindGameObjectWithTag("Stamina").GetComponent<Text>().text = "Stamina " + Stamina;
            ScaredCooldown = 10;
	        AtOrigin = false;
	    }
	    if (Following)
	    {
            Debug.Log(("VOLGEN"));
	        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            transform.transform.LookAt(player.transform);

            var distance = Vector3.Distance(transform.position, player.GetComponent<Renderer>().bounds.center);
            Debug.Log("DE AFSTAND IS " + distance);
	        if (distance > 10)
	        {
	            Debug.Log("het ken");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
	                1 * Time.deltaTime / 10);
	        }
	    }

	   // if (gameObject.transform.position == OriginPoint)
	   // {
	     //   AtOrigin = true;
	   // }
	    if (AtOrigin)
	    {
	       // transform.Rotate((new Vector3(0, 2, 0) * 2 * Time.deltaTime));
	       // transform.Translate(Vector3.forward * 1 * Time.deltaTime);
	    }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("HALLO");
        }

    }
}
