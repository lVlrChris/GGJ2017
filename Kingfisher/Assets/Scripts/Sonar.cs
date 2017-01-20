using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public bool SonarActive = false;
    public Player player;
    public Fish fish;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;

    }

    // Update is called once per frame
    void Update ()
	{
	    if (SonarActive)
	    {
            GetComponent<Renderer>().enabled = true;
        }
	    else
	    {
            GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetKeyDown(("e")))
        {
            SonarActive = true;
        }
        if (Input.GetKeyUp("e"))
        {
            SonarActive = false;
        }

        if (!SonarActive && fish != null)
        {
            float distance = Vector3.Distance(gameObject.transform.position, fish.gameObject.transform.position);
            //Debug.Log(distance);
            if (distance <= 4)
            {
                fish.gameObject.transform.LookAt(gameObject.transform);
                fish.gameObject.transform.Rotate(0, 180, 0);
                fish.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            }

        }

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Fish") && SonarActive)
        {
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, transform.position, 1 * Time.deltaTime);
        }


    }

}
        //transform.position = player.gameObject.transform.position;
        // transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, 0.03f);


