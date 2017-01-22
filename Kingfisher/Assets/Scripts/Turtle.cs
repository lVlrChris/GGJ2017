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
    public AudioClip ConfettiSound, CheerSound, CrySound;
    AudioSource audioSource;

    private bool crying; 
	// Use this for initialization
    private Animation animation;
	void Start ()
	{
	    animation = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAnimation()
    {
        audioSource.PlayOneShot(ConfettiSound, 0.7f);
        audioSource.PlayOneShot(CheerSound, 0.7f);
        animationPlaying = true;
    }

    public void Cry()
    {

        crying = true;
        audioSource.PlayOneShot(CrySound, 0.7f);
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
	        else if(animationCount >= animationPlayTime)
	        {
	            animationPlaying = false;
	            animationCount = 0;
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
                    tearsCount = 0;
                }

            }

        }
    }
}
