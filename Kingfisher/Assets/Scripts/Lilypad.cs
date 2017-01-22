using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lilypad : MonoBehaviour
{
    public Rijger bird;
    private GameObject[] turtles;

	// Use this for initialization
	void Start () {
        turtles = GameObject.FindGameObjectsWithTag("Turtle");


    }

    // Update is called once per frame
    void Update () {

		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            // other.GetComponent<Fish>().lilyPosition = transform.position;
            if (bird.Attacking)
            {
                other.GetComponent<Fish>().AtLily = true;
                other.GetComponent<Fish>().ignorePlayer = true;

                other.GetComponent<Fish>().speed = 0;
                bird.Attacking = false;
                bird.Retreating = true;

                Debug.Log(("IS DIT HET NOU/"));
                var scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
                scoreManager.score += 10;
                GameObject.FindGameObjectWithTag("Stamina").GetComponent<Text>().text = "Score " + scoreManager.score;


                foreach (var turtle in turtles)
                {
                    turtle.GetComponent<Turtle>().PlayAnimation();
                }
            }

            Debug.Log("LILYPAAAD");

        }


    }
}
