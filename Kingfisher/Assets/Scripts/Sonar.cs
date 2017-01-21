using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Sonar : MonoBehaviour
{
    public bool SonarActive = false;
    public ParticleSystem particles;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;

	}




    // Update is called once per frame
    void Update ()
	{
	    if (SonarActive)
	    {
            //GetComponent<Renderer>().enabled = true;
	        if (!particles.isEmitting)
	        {
	            particles.enableEmission = true;
	            particles.Play();
	        }
	       // GetComponent<Collider>().enabled = true;
	    }
	    else
	    {
           // particles.enableEmission = false;
           // GetComponent<Collider>().enabled = false;

	    }


        //if (Input.GetKeyDown(("space")))
        if(XCI.GetButtonDown(XboxButton.RightBumper) || Input.GetKeyDown(("space")))
        {
            SonarActive = true;
        }
        if (XCI.GetButtonUp(XboxButton.RightBumper) || Input.GetKeyUp(("space")))
        {
            SonarActive = false;
        }

       // if (!SonarActive && fish != null)
       // {
        //    float distance = Vector3.Distance(gameObject.transform.position, fish.gameObject.transform.position);
          //Debug.Log(distance);
          //  if (distance <= 1.5)
          //  {
           //     fish.IsScared = true;
            //    fish.LastScared = DateTime.Now;
            //    fish.gameObject.transform.LookAt(gameObject.transform);
             //   fish.gameObject.transform.Rotate(0, 180, 0);
        //       if (fish.gameObject.transform.position.x < 3.5 && fish.gameObject.transform.position.z < 2.6)
         //      {
           //         fish.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            //\w   }
            //}
        //}

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Fish") && SonarActive)
        {
            other.GetComponent<Fish>().Following = true;
            other.gameObject.transform.LookAt(gameObject.transform);
            if (!other.GetComponent<Fish>().ignorePlayer)
            {
                other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, transform.position, 1 * Time.deltaTime / 2);
                other.gameObject.transform.rotation = transform.rotation;

            }
        }
        else if (other.CompareTag("Fish") && !SonarActive)
        {
            Fish fish = other.GetComponent<Fish>();
            fish.IsScared = true;
            fish.LastScared = DateTime.Now;
            Debug.Log("HET IS EEN WONDER " + fish.GetComponent<Fish>().IsScared);
            fish.gameObject.transform.LookAt(gameObject.transform);
            fish.gameObject.transform.Rotate(0, 180, 0);
        }

    }

}
        //transform.position = player.gameObject.transform.position;
        // transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, 0.03f);


