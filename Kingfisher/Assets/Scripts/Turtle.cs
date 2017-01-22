using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    private bool animationPlaying;
    public int animationPlayTime = 4;
    private int animationCount = 0;
	// Use this for initialization
	void Start () {
		
	}

    public void PlayAnimation()
    {
        animationPlaying = true;
    }

    // Update is called once per frame
    void Update () {
	    if (animationPlaying)
	    {
	        if (animationCount < animationPlayTime)
	        {
	            GetComponent<Animation>().Play();
                animationCount++;
	        }
	    }
		
	}
}
