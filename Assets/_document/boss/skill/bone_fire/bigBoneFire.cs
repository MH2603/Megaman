using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBoneFire : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);

        if(  transform.position.x <= 0) 
        {
            Destroy(gameObject);
        }
    }



    void OnTriggerEnter2D( Collider2D other )
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController2D_new>().ApplyDamage(2f, transform.position);
        }
    }
}
