using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int BulletSpeed = 10;
    private GameObject BulletObject;

    // Use this for initialization
    void Start ()
    {
        BulletObject = gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        BulletObject.transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
    }
}
