using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    private bool animationPlaying;
    private int animationPlayTime = 4;
    private int animationCount = 0;
    public ParticleSystem[] particles;
    private int tearsPlayTime = 4;
    private int tearsCount = 0;


    private bool crying; 
	// Use this for initialization
    private Animation animation;
	void Start ()
	{
	    animation = GetComponent<Animation>();
	}

    public void PlayAnimation()
    {
        animationPlaying = true;
    }

    public void Cry()
    {
        crying = true;
    }

    // Update is called once per frame
    void Update () {
	    if (animationPlaying)
	    {
	        if (animationCount < animationPlayTime && !animation.isPlaying)
	        {
	            animation.Play();
	            
                animationCount++;
	        }
	    }

        if (crying)
        {
            foreach (var particle in particles)
            {
                if (!particle.isEmitting && tearsCount < tearsPlayTime)
                {
                    particle.enableEmission = true;
                    particle.Play();
                    tearsCount++;
                }
                else if(tearsCount >= tearsPlayTime )
                {
                    Debug.Log("STOP MET HUILEN PLS");
                    crying = false;
                }

            }

        }
    }
}
