using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anima;

    public Collider2D coll;

    public boss_action action;

    bool firstOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && firstOpen )
        {
            anima.SetBool("open", true);
            coll.isTrigger = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            firstOpen = false;

            anima.SetBool("close", true);

            anima.SetBool("open", false);

            coll.isTrigger = false;


            action.step ++;

            Invoke("StartGame", 6f);
            return;

        }



    }


    void StartGame()
    {
        action.step ++;
    }
}
