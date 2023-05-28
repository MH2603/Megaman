using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_skill : MonoBehaviour
{
    public boss_action action;

    public Animator anima;

    
    public GameObject player;
    public GameObject smokes;

    //AN
    public float runSpeed;
    float k;
    public GameObject checkAN;
    
    //Bullet
    public GameObject bone;

    //Dash
    public GameObject prepareDash;
    public Transform[] posDash;

    //wind
    public GameObject wind;
    public Transform poinSpawWind;

    //Bone_Fire
    public GameObject boneFire;
    public GameObject bigBoneFire;
    public Transform posSpawFire;

    // Bone_Lightning
    public Transform posMid;
    public GameObject boneLightning;


    //Lightning
    public GameObject twoLightning;


    //UNDEAD

    public bossHP HP;

    Rigidbody2D rb;

    // Sound
    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    

    // Attack Normal
    public void RunToPlayer()
    {

        

        k = Mathf.Abs(transform.position.x - player.transform.position.x);

        FlipToPlayer();

        anima.SetBool("run", true);
        anima.SetFloat("distan", k);

        rb.velocity = new Vector2(transform.localScale.x * runSpeed, 0f);

        
        
        if ( k <= 5f   )
        {
            rb.velocity = new Vector2(0, 0);

            action.step++;
            action.startTime = Time.time;

            checkAN.SetActive(true);
            return;
        }

        
    }

    // Bullet

    public void Bullet()
    {
        FlipToPlayer();

        action.startTime = Time.time; 
        for(int i= 0; i <= 3; i++)
        {
            Invoke("SpawBone", i*1f);
            
        }
        action.step++;
        return;
    }

    public void SpawBone()
    {
        Vector3 posBullet = transform.position;
        posBullet.y += 1.5f;

        GameObject bullet = Instantiate(bone, posBullet, Quaternion.identity);

        Vector2 huong = player.transform.position - posBullet;

        bullet.GetComponent<Rigidbody2D>().AddForce(huong.normalized * 100f);
    }

    // Dash

    public void PrepareDash()
    {
        

        anima.SetBool("prepareDash", true);
        prepareDash.SetActive(true);

        action.startTime = Time.time;
        action.step++;
    }

    public void Dash()
    {
        anima.SetBool("isDash", true);
        prepareDash.SetActive(false);
        transform.position = Vector3.Lerp(transform.position, posDash[0].position, 6f * Time.deltaTime);

        if( Mathf.Abs(transform.position.x - posDash[0].position.x) < 1)
        {
            Transform m = posDash[0].transform;
            posDash[0]= posDash[1];
            posDash[1] = m;

            anima.SetBool("isDash", false);
            

            action.startTime = Time.time;
            action.step++;

            return;

        }
    }


    // Spaw Wind
    public void SkillWind()
    {
        Flip(false);
        anima.SetBool("wind", true);
        StartCoroutine(SpawWind());

        action.startTime = Time.time;
        action.step++;

        return;
    }

    public IEnumerator SpawWind()
    {
        yield return new WaitForSeconds(0.3f);

        Instantiate(wind, poinSpawWind.position, Quaternion.identity);


    }

    // Bone_fire
    public void prepareBoneFire()
    {
        FlipToPlayer();

        anima.SetBool("prepareSpawBone", true);
        GameObject BoneFire =  Instantiate(boneFire,transform.position, Quaternion.identity);
        Vector2 m = new Vector2(0, 50);
        BoneFire.GetComponent<Rigidbody2D>().AddForce( m );

        action.startTime = Time.time;
        action.step++;

        return ;
    }


    public void BoneFire()
    {
        Instantiate(bigBoneFire, posSpawFire.position, Quaternion.identity);

        action.startTime = Time.time;
        action.step++;
    }

    // Bone_Lightning

    public void prepareBoneLightning()
    {
        Tele(posMid.position);

        anima.SetBool("scream", true);

       

        Instantiate(boneLightning, transform.position, Quaternion.identity);

        action.startTime = Time.time;
        action.step++;

        return;
    }

    //UNDEAD

    public void StartUNDEAD()
    {
        anima.SetBool("undead", true);
        anima.SetBool("startUnDead", true);

        rb.velocity = Vector2.zero;


        action.stepDead++;
        action.startTimeDead = Time.time;

        return;
    }

    public void MidUNDEAD()
    {
        HP.Reset();

        action.stepDead++;
        action.startTimeDead = Time.time;

        return;

    }

    // DEAD

    public void DEAD()
    {
        rb.velocity = Vector2.zero;

        anima.SetBool("dead", true);
        anima.SetBool("undead", true);

        action.step = 0;
        action.stepWin ++;

        return;
    }


    // BossWin
    public void BossWin()
    {
        rb.velocity = Vector2.zero;

        anima.SetBool("scream", true);

        action.step = 0;
        action.stepWin ++;

        return;
    }


    // Lightning
    public void SetTwoLightning(bool tf)
    {
        twoLightning.SetActive(tf);
    }

    //Flip
    public void FlipToPlayer()
    {

        if (transform.position.x - player.transform.position.x >= 0) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }

    public void Flip(bool right)
    {
        Vector3 m = transform.localScale;

        if (right) m.x = 1;
        else if(!right) m.x = -1;

        transform.localScale = m;
    }

    // Tele
    void Tele(Vector3 pos)
    {
        Vector3 m = transform.position; m.y += 2;
        GameObject smoke = Instantiate(smokes, m, Quaternion.identity);
        transform.position = pos;
        Destroy(smoke, 0.5f);
    }

    // Collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController2D_new>().ApplyDamage(2f, transform.position);
        }
    }

    // Start

    public void StartSolo()
    {

        FlipToPlayer();
        anima.SetBool("scream", true);

        action.step++;
        return;

    }






}
