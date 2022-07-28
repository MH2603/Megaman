using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_move : MonoBehaviour
{
    public Animator anima;

    public LayerMask other;
    public bool m = false;

    public Transform newPosition;
    public float runSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition.position, runSpeed * Time.deltaTime);
        

         m = Physics2D.OverlapCircle(transform.position,1, other);
        if(m)
        {
            anima.SetBool("destroy", true);
            Destroy(gameObject, 0.25f);
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController2D_new>().ApplyDamage(2f, transform.position);
        }
    }


    

    
}
