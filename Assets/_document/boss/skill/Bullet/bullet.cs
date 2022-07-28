using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            anima.SetBool("destroy", true);
            Invoke("Destroy", 0.41f);
        }

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController2D_new>().ApplyDamage(2f, transform.position);
        }


    }


}
