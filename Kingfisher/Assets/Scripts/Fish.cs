using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public GameObject Rocks;
    public Vector3 OriginPoint;
    public bool IsScared = false;
    public bool AtOrigin = false;
    public float ScaredCooldown = 10.0f;
    public DateTime LastScared;

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
	void Update () {
        float distance = Vector3.Distance(Rocks.gameObject.transform.position, gameObject.transform.position);
        //Debug.Log(distance);
        /* if (distance <= 4)
         {
             gameObject.transform.LookAt(gameObject.transform);
             gameObject.transform.Rotate(0, 180, 0);
             gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
         }
         */

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
	        Stamina -= 0.01f;
            GameObject.FindGameObjectWithTag("Stamina").GetComponent<Text>().text = "Stamina " + Stamina;
            ScaredCooldown = 10;
	        AtOrigin = false;
	    }
	    if (!IsScared )
	    {

            transform.position = Vector3.MoveTowards(transform.position, OriginPoint, 1 * Time.deltaTime);
	    }
	    if (gameObject.transform.position == OriginPoint)
	    {
	        AtOrigin = true;
	    }
	    if (AtOrigin)
	    {
	        transform.Rotate((new Vector3(0, 2, 0) * 2 * Time.deltaTime));
	        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
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
