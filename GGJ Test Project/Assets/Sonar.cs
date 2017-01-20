using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public bool SonarActive = false;
    public Player player;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;

    }

    // Update is called once per frame
    void Update ()
	{
        Debug.Log(SonarActive);
	    if (SonarActive)
	    {
            Debug.Log("blo");

            GetComponent<Renderer>().enabled = true;
        }
	    else
	    {
            GetComponent<Renderer>().enabled = false;
        }
    }

}
        //transform.position = player.gameObject.transform.position;
        // transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, 0.03f);


