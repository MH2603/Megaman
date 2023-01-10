using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSetting : MonoBehaviour
{

    public AudioSource audio;

    public AudioClip[] clips;


    public Attack_new attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSound( int s,float v)
    {
        audio.volume = v;
        audio.PlayOneShot(clips[s]);   
    }



    public void SetSound(int s, float v, bool loop)
    {
        audio.clip = clips[s];
        audio.volume = v;
        audio.Play();

        
        audio.loop = loop;
    }

    public void OffSound()
    {
        audio.clip = null;
    }
}
