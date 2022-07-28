using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAN : MonoBehaviour
{

    public float m = 0;

    public float n = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {

        m = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (m <= Time.time - n) this.gameObject.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
       
        if(other.gameObject.tag == "Player" && m <= Time.time - 0.8f)
        {
            other.gameObject.GetComponent<CharacterController2D_new>().ApplyDamage(2f, transform.position);
            Debug.Log("okokook");
        }
    }
}
