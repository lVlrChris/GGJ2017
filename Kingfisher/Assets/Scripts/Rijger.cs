using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XboxCtrlrInput;

public class Rijger : MonoBehaviour
{
    public GameObject fish;
    public int Speed = 10;
    public GameObject shadow;
    public bool Attacking = false;
    public bool Retreating = false;

    public List<Fish> ListOfFish = new List<Fish>();
    private Fish currentTarget;
    private Vector3 startPosition;
    private Vector3 shadowStartPosition;
    private Vector3 shadowSize;

	// Use this for initialization
	void Start () {
		shadow = GameObject.FindGameObjectWithTag("Shadow");
	    currentTarget = PickRandomTarget();
	    startPosition = transform.position;
        Debug.Log("START POSITION   " + startPosition);

	    shadowStartPosition = shadow.transform.position;
	    shadowSize = shadow.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(("z")) && !Attacking)
        if ((XCI.GetButton(XboxButton.Back)|| Input.GetKey(("z"))) && !Attacking)
        {

            
            //fish = GameObject.FindGameObjectWithTag("Fish");
            if (currentTarget != null)
            {
                //shadow.transform.position = currentTarget.gameObject.transform.position;
                Attacking = true;
                Debug.Log("ATTACKKING " + currentTarget);
            }
            else
            {
                currentTarget = PickRandomTarget();
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

	    if (transform.position.x >= 7)
	    {
            Debug.Log("JAJAJAJAJAJAJAJA");
            transform.position = (startPosition);
	        Retreating = false;
	        shadow.transform.position = (shadowStartPosition);
	        shadow.transform.localScale = shadowSize;
	    }
    }

    void Attack()
    {
        shadow.transform.position = Vector3.MoveTowards(shadow.transform.position, currentTarget.gameObject.transform.position, Speed * Time.deltaTime);
        // 
       // gameObject.transform.Translate(Vector3.right * Time.deltaTime * Speed);

        shadow.transform.localScale += new Vector3(0.000015f, 0f, 0.000015f);
        float distance = Vector3.Distance(shadow.gameObject.transform.position, currentTarget.gameObject.transform.position);
        if (distance < 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, shadow.gameObject.transform.position, (Speed * 5) * Time.deltaTime);
        }

    }

    void Retreat()
    {

        //shadow.transform.localScale -= new Vector3(0.02f, 0f, 0.02f);
        shadow.transform.Translate(Vector3.right * (Speed * 2) * Time.deltaTime);
        gameObject.transform.Translate(new Vector3(1,1,0) * (Speed * 2) * Time.deltaTime);

    }

    

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Fish"))
        {
            ListOfFish.Remove(other.GetComponent<Fish>());
            foreach (var o in ListOfFish)
            {
                Debug.Log("list item " + o.name);
            }
            Debug.Log("SIZE VAN LIST " + ListOfFish);
            Destroy(other.gameObject);
            Retreating = true;
            Attacking = false;
            if (ListOfFish.Count <= 0)
            {
                Debug.Log("GAME OVER");
                Application.Quit();
            }

        }
        if (other.CompareTag("Bird"))
        {
            Attacking = false;
        }


    }

    Fish PickRandomTarget()
    {
        var randomIndex = Random.Range(0, ListOfFish.Count);
        currentTarget = ListOfFish.ElementAt(randomIndex);
        return currentTarget;
    }

}
