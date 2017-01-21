using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilypad : MonoBehaviour
{
    public Rijger bird;

	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            // other.GetComponent<Fish>().lilyPosition = transform.position;
            other.GetComponent<Fish>().AtLily = true;
            other.GetComponent<Fish>().ignorePlayer = true;

            other.GetComponent<Fish>().speed = 0;
            Debug.Log("LILYPAAAD");
            bird.Attacking = false;
            bird.Retreating = true;
        }


    }
}
