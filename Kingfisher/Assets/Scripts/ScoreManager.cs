using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    private float startTime;
    private float playTime;

	// Use this for initialization
	void Start ()
	{
	    startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    playTime = Time.time - startTime;
        //GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>().text = "" + playTime;
    }
}
