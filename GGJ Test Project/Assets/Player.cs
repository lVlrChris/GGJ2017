using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MovementSpeed = 1;
    public int RotationSpeed = 10;
    public int BulletCooldown = 2;
    private bool CanFireBullet = true;
    private float BulletTimestamp;

    public GameObject Bullet;


    private GameObject Submarine;
	// Use this for initialization
	void Start ()
	{
	    Submarine = gameObject;
       // Bullet = GameObject.FindGameObjectWithTag("Bullet");
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (BulletTimestamp <= Time.time && !CanFireBullet)
	    {
	        CanFireBullet = true;
            Debug.Log("Cooldown reset");
	    }


	    if (Input.GetKey("w"))
	    {
	     //   Submarine.transform.position = Vector3.Lerp(StartPosition.position, StartPosition.position, JourneyFraction);
	        Submarine.transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
	    }
	    if (Input.GetKey(("a")))
	    {
	        Submarine.transform.Rotate(new Vector3(0, -RotationSpeed, 0) * RotationSpeed *Time.deltaTime);
	    }
        if (Input.GetKey(("d")))
        {
            Submarine.transform.Rotate(new Vector3(0, RotationSpeed, 0)  * RotationSpeed * Time.deltaTime);
        }


        //food
	    if (Input.GetKeyDown(("q")) && CanFireBullet)
	    {
            CanFireBullet = false;
            BulletTimestamp = Time.time + BulletCooldown;
            Debug.Log("fired");
	        
            Instantiate(Bullet, Submarine.transform.position, transform.rotation);
        }

        //sonar
	    if (Input.GetKey(("e")))
	    {

	        
	    }

    }
}
