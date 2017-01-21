using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Rijger : MonoBehaviour
{
    public GameObject fish;
    public int Speed = 200;
    public GameObject Schaduw;
    public bool Attacking = false;
    public bool Retreating = false;

    public GameObject[] ListOfFish;
    private GameObject currentTarget;


	// Use this for initialization
	void Start () {
		Schaduw = GameObject.FindGameObjectWithTag("Shadow");
	    currentTarget = PickRandomTarget();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(("z")) && !Attacking)
        if ((XCI.GetButton(XboxButton.Back)|| Input.GetKey(("z"))) && !Attacking)
        {

            Debug.Log("DE VIS IS NU " + currentTarget.name);

            //fish = GameObject.FindGameObjectWithTag("Fish");
            if (currentTarget != null)
            {
                Schaduw.transform.position = currentTarget.gameObject.transform.position;
                Attacking = true;
                Debug.Log("ATTACK?");
            }
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
        Schaduw.transform.position = Vector3.MoveTowards(Schaduw.transform.position, currentTarget.gameObject.transform.position, Speed * Time.deltaTime);
        // 
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * Speed);

        Schaduw.transform.localScale += new Vector3(0.0015f, 0f, 0.0015f);
        float distance = Vector3.Distance(gameObject.transform.position, currentTarget.gameObject.transform.position);
        if (distance < 10)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Schaduw.gameObject.transform.position, (Speed * 2) * Time.deltaTime);
        }

    }

    void Retreat()
    {
        if (Schaduw.transform.localScale.x > 0)
        {
            Schaduw.transform.localScale -= new Vector3(0.02f, 0f, 0.02f);
        }
        gameObject.transform.Translate(new Vector3(1,1,0) * Speed * Time.deltaTime);

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Fish"))
        {

            Destroy(other.gameObject);
            Retreating = true;
            Attacking = false;

        }
        if (other.CompareTag("Bird"))
        {
            Attacking = false;
        }


    }

    GameObject PickRandomTarget()
    {
        var randomIndex = Random.Range(0, ListOfFish.Length);
        currentTarget = ListOfFish[randomIndex];
        return currentTarget;
    }

}
