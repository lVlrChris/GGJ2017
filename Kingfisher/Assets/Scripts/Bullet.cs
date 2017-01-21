using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void OnTriggerStay(Collider other)
    {
        Debug.Log("BULLETHIT");
        if (other.CompareTag("Fish"))
        {
            Destroy(gameObject);
            other.GetComponent<Fish>().Stamina += 50;
            /*
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, transform.position, 1 * Time.deltaTime);
            other.gameObject.transform.rotation = transform.rotation;
            */
        }


    }
}
