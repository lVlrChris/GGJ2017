﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rijger : MonoBehaviour
{
    public Fish fish;
    public int Speed = 1;
    public GameObject Schaduw;
    public bool Attacking = false;
	// Use this for initialization
	void Start () {
		Schaduw = GameObject.FindGameObjectWithTag("Shadow");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(("z")))
        {
            Schaduw.transform.position = fish.gameObject.transform.position;
            Attacking = true;

        }
	    if (Attacking)
	    {
	        Attack();
	    }
    }

    void Attack()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Schaduw.gameObject.transform.position, Speed * Time.deltaTime /5 );
        Schaduw.transform.localScale += new Vector3(0.005f, 0f, 0.005f);
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Bird"))
        {
            Attacking = false;
        }


    }
}
