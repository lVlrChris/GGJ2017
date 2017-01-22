using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : MonoBehaviour
{
    public int MovementSpeed = 1;
    public int RotationSpeed = 10;
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
	    }


        //if (Input.GetKey("w"))
        if(XCI.GetButton(XboxButton.DPadUp) || Input.GetKey("w"))
        {
	     //   Submarine.transform.position = Vector3.Lerp(StartPosition.position, StartPosition.position, JourneyFraction);
	        Submarine.transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
            gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.transform.Rotate(Vector3.right * 30 * Time.deltaTime);
	    }
        if (XCI.GetButton(XboxButton.DPadLeft) || Input.GetKey("a"))

        {
            Submarine.transform.Rotate(new Vector3(0, -RotationSpeed, 0) * RotationSpeed *Time.deltaTime);
	    }
        if (XCI.GetButton(XboxButton.DPadRight) || Input.GetKey("d"))

        {
            Submarine.transform.Rotate(new Vector3(0, RotationSpeed, 0)  * RotationSpeed * Time.deltaTime);
        }


        //food
        //if (Input.GetKeyDown(("q")) && CanFireBullet)
        if ((XCI.GetButtonDown(XboxButton.LeftBumper) || Input.GetKeyDown(("q")  ) && CanFireBullet))
        {
            CanFireBullet = false;
            BulletTimestamp = Time.time + BulletCooldown;
	        
            Instantiate(Bullet, Submarine.transform.position, transform.rotation);
        }

        //sonar

        if (Input.GetKeyDown(("r")))
	    {
            Application.LoadLevel("Main Menu");
        }

    }
}
