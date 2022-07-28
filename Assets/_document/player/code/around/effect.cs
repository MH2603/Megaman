using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{

	public GameObject player;

	public GameObject ghostDash;

    public float timeSpaw;

    public float n,m;
    bool run = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool dashing = player.GetComponent<CharacterController2D_new>().isDashing;

        if (dashing  && run)
        {
            for(int i = 0; i < 4; i++)
            {
                
                Invoke("SpawGhost", timeSpaw * i);
                n++;
            }
            run = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && !dashing) run = true; 

    }

    void SpawGhost()
    {
        

        GameObject ghost = Instantiate(ghostDash, this.transform.position, Quaternion.identity);
        ghost.transform.localScale = player.transform.localScale;
        StartCoroutine(ClearGhosts(ghost));

    }

    IEnumerator ClearGhosts(GameObject ghost)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(ghost);
    }
}
