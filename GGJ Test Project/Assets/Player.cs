using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MovementSpeed = 1;
    public int RotationSpeed = 1000;
    public int BulletCooldown = 1;
    private bool CanFireBullet = true;
    private float BulletTimestamp;

    public GameObject Bullet;
    public Sonar SonarObject;
    

    private GameObject Submarine;
	// Use this for initialization
	void Start ()
	{
	    Submarine = gameObject;
        // SonarObject = Instantiate(SonarObject, Submarine.transform.position, transform.rotation);

        //Sonar.SetActive(false);
        //Bullet = GameObject.FindGameObjectWithTag("Bullet");

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

    }
}
