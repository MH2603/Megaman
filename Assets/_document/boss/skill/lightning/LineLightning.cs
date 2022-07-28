using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLightning : MonoBehaviour
{
    LineRenderer lineRenderer;

    public Texture[] textures;

    public bool destroy = false;
    public float timeLife = 0.5f;

    int animationStep;

    public float fbs;

    float fbsCounter;

    float startTime;
    void Awake() 
    {
        lineRenderer = GetComponent<LineRenderer>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        fbsCounter += Time.deltaTime;

        if(fbsCounter >= 1 / fbs)
        {
            animationStep ++;

            if(animationStep == textures.Length) animationStep = 0;
           
            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

            fbsCounter = 0f;
        }


        if (destroy) Life();
    }


    public void Life()
    {
        
        if( startTime <= Time.time - timeLife) Destroy(this.gameObject);
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            other.gameObject.GetComponent<CharacterController2D_new>().ApplyDamage(2f, transform.position);
            Debug.Log("lightning in the thunder");
        }
    }
}
