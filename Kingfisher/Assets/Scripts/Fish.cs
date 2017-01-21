using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject Rocks;
    public Vector3 OriginPoint;
    public bool IsScared = false; 

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
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("HALLO");
        }

    }
}
