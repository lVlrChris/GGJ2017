using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
