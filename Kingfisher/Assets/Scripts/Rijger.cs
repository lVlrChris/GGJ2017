using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rijger : MonoBehaviour
{
    public GameObject fish;
    public int Speed = 200;
    public GameObject Schaduw;
    public bool Attacking = false;
    public bool Retreating = false;
	// Use this for initialization
	void Start () {
		Schaduw = GameObject.FindGameObjectWithTag("Shadow");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(("z")) && !Attacking)
        {
            fish = GameObject.FindGameObjectWithTag("Fish");
            Schaduw.transform.position = fish.gameObject.transform.position;
            Attacking = true;
            Debug.Log("ATTACK");
        }
	    if (Attacking)
	    {
	        Attack();
	    }
	    if (Retreating)
	    {
	        Retreat();
	    }
    }

    void Attack()
    {
        Schaduw.transform.position = Vector3.MoveTowards(Schaduw.transform.position, fish.gameObject.transform.position, Speed * Time.deltaTime);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Schaduw.gameObject.transform.position, Speed * Time.deltaTime /5 );

            Schaduw.transform.localScale += new Vector3(0.001f, 0f, 0.001f);
        
    }

    void Retreat()
    {
        if (Schaduw.transform.localScale.x > 0)
        {
            Schaduw.transform.localScale -= new Vector3(0.02f, 0f, 0.02f);
    }
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
