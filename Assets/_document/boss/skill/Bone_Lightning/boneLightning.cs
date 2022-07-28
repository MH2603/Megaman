using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneLightning : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public GameObject effectLightning;

    bool hasSpaw = false ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(transform.position.y >= 13)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector2 m = new Vector2(0, speed);
            rb.velocity = m;
        }


        if ( transform.position.y >= 13 && hasSpaw == false )
        {
            for ( int i=0;i <= 7 ;i++)
            {
              
                StartCoroutine(SpawEffect(i));
            }

            hasSpaw = true;
        }

        

        
    }

    IEnumerator SpawEffect(float k)
    {

        yield return new WaitForSeconds( k * 0.4f);

        Vector3 m = transform.position;
        m.x += k*2.5f;

        Vector3 n = transform.position;
        n.x += -k*2.5f;

        Quaternion l = transform.rotation;
        l = Quaternion.Euler(Vector3.right * 90);

        GameObject effect_right = Instantiate(effectLightning, m, l);


        GameObject effect_left = Instantiate(effectLightning, n, l);
    }
}
