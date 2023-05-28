using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHP : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color takeDMG;
    Color colorStart;

    public HealthBar BossHP;
    public boss_action action;

    public GameObject fireSkull;

    public float life = 80;

    public bool fistDead = false;


    // Start is called before the first frame update
    void Start()
    {
        colorStart = sprite.color;
        BossHP.SetMaxHealth(life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        if (life <= 0) return;

        life -= damage;
        sprite.color = takeDMG;
        Invoke("ChangeColor",0.5f);

        BossHP.SetHealth(life);
        if(life <= 0 && fistDead == false )
        {
            fistDead = true;

            action.stepDead++;
            action.startTimeDead = Time.time;

            return;
        }
    }

    void ChangeColor()
    {
        sprite.color = colorStart;
    }


    public void Reset()
    {
        life = 80;
        BossHP.SetHealth(life);
        fireSkull.SetActive(true);
    }
}
