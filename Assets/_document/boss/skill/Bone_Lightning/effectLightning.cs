using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectLightning : MonoBehaviour
{
    public GameObject lightning;


    public float timeSpaw = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SpawLightning", timeSpaw);
    }

    void SpawLightning()
    {
        Instantiate(lightning,transform.position,Quaternion.identity);

        Destroy(gameObject);

        return;
    }
}
