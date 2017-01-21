using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject Rocks;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(Rocks.gameObject.transform.position, gameObject.transform.position);
        Debug.Log(distance);
       /* if (distance <= 4)
        {
            gameObject.transform.LookAt(gameObject.transform);
            gameObject.transform.Rotate(0, 180, 0);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        */  
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(gameObject.tag);
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
        }

    }
}
