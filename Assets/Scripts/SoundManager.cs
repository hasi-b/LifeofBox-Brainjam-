using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, health, pew,hurt,lost,pop;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("Jump");
        health = Resources.Load<AudioClip>("Health");
        pew = Resources.Load<AudioClip>("fire");
        hurt = Resources.Load<AudioClip>("hurt");
        lost = Resources.Load<AudioClip>("Lost");
        pop = Resources.Load<AudioClip>("pop");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSrc.PlayOneShot(pew);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "health":
                audioSrc.PlayOneShot(health);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurt);
                break;
            case "lost":
                audioSrc.PlayOneShot(lost);
                break;
            case "pop":
                audioSrc.PlayOneShot(pop);
                break;

        }
    }

}
