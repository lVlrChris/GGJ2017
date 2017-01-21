using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class Fish : MonoBehaviour
{
    public Vector3 OriginPoint;
    public bool IsScared = false;
    public bool AtOrigin = false;
    public float ScaredCooldown = 10.0f;
    private float LilyCooldown = 4.0f;

    public DateTime LastScared;
    public bool Following = false;

    public bool AtLily = false;
    public float Stamina = 100;

    public bool ignorePlayer = false;

    public Vector3 lilyPosition;

    public int speed = 1;

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

    void CheckSonar()
    {
        if (XCI.GetButtonUp(XboxButton.RightBumper) || Input.GetKeyUp(("space")))
        {
            Following = false;
        }

    }

    void CheckIfScared()
    {
        if (IsScared && !ignorePlayer)
        {


            if (gameObject.transform.position.x < 3.5 && gameObject.transform.position.z < 2.6 && gameObject.transform.position.x >  -3.50)
            {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            Stamina -= 0.01f;
            GameObject.FindGameObjectWithTag("Stamina").GetComponent<Text>().text = "Stamina " + Stamina;
            ScaredCooldown = 10;
            AtOrigin = false;
        }
    }

    void CheckCooldown(float timer)
    {
        
    }

    void CheckIfFollowing()
    {
        if (Following && !ignorePlayer)
        {
            Debug.Log(("VOLGEN"));
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            transform.transform.LookAt(player.transform);

            var distance = Vector3.Distance(transform.position, player.GetComponent<Renderer>().bounds.center);
            if (distance > 10)
            {
                Debug.Log("het ken");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                    speed * Time.deltaTime / 10);
            }
        }
    }

	// Update is called once per frame
	void Update ()
	{
        //Debug.Log(distance);
        /* if (distance <= 4)
         {
             gameObject.transform.LookAt(gameObject.transform);
             gameObject.transform.Rotate(0, 180, 0);
             gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
         }
         */
        DateTime currentDate = DateTime.Now;



        long elapsedLilyTicks = currentDate.Ticks - LastScared.Ticks;
        TimeSpan elapsedLilySpan = new TimeSpan(elapsedLilyTicks);

        if (elapsedLilySpan.TotalSeconds >= LilyCooldown)
        {

            AtLily = false;
            ignorePlayer = false;
        }



        CheckSonar();


        //als vis niet bang is ga na 10 sec terug naar beginpunt
        long elapsedTicks = currentDate.Ticks - LastScared.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
	    if (elapsedSpan.TotalSeconds >= ScaredCooldown)
	    {
	        IsScared = false;
            gameObject.transform.LookAt(OriginPoint);

        }




        if (Stamina > 100) Stamina = 100;

        CheckIfScared();

        CheckIfFollowing();

        // if (gameObject.transform.position == OriginPoint)
        // {
        //   AtOrigin = true;
        // }
        //	    if (AtOrigin)
        //  {
        //       // transform.Rotate((new Vector3(0, 2, 0) * 2 * Time.deltaTime));
        // transform.Translate(Vector3.forward * 1 * Time.deltaTime);
        // }
        if (AtLily)
        {
            Debug.Log("PLS DOE HET NOUUU");
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
            speed = 0;
            transform.Translate(lilyPosition);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Rocks"))
        {
            Debug.Log("HALLO");
        }

    }
}
