﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_new : MonoBehaviour
{
	public float dmgValue = 4;

	public GameObject throwableObject_1;
	public GameObject throwableObject_2;
	public GameObject throwableObject_3;
	GameObject throwableObject;

	public Transform attackCheck;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;

	public GameObject cam;


	public Transform firePoint;
	bool fire = false;
	float start = 0;
	public float timeDown;
	public SpriteRenderer colorEffect;
	public GameObject effect;
	public float m;

	float startTime;


	public audioSetting audio;
	float step;


	// Start is called before the first frame update
	void Start()
    {
		startTime = Time.time + 3f;
    }

	// Update is called once per framea
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.X) && canAttack)
		//{
		//	canAttack = false;
		//	animator.SetBool("IsAttacking", true);
		//	StartCoroutine(AttackCooldown());
		//}

		


		if (Input.GetKeyUp(KeyCode.J) && startTime < Time.time)
		{

			if(step > 1) audio.GetSound(6, 0.3f);
			audio.OffSound();
			step = 0;
			

			//if(fire == false) StartCoroutine(DownFire()); 
			fire = true;
			start = Time.time;

			effect.SetActive(false);
			DownFire();
			

			if (throwableObject == null) return;
            else
            {
				GameObject throwableWeapon = Instantiate(throwableObject, firePoint.position, Quaternion.identity) as GameObject;
				Vector2 direction = new Vector2(transform.localScale.x, 0);
				throwableWeapon.GetComponent<Bullet_move>().direction = direction;
				
			}

			m = 0;

		}
		else if (Input.GetKeyDown(KeyCode.J) && startTime < Time.time){

			m = Time.time;
			effect.SetActive(true);

			step = 1;
		}

		if ( effect != null )
        {
			ChangeColor();
        }

		if (start + 0.6 < Time.time) fire = false;	

		animator.SetBool("Fire", fire);
	}

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
		
	}

	void DownFire()
    {
		m = Time.time - m;

		

		if (m < timeDown)
		{
			throwableObject = throwableObject_1;
		}
		else if (m >= timeDown && m < 2 * timeDown)
		{
			throwableObject = throwableObject_2;
		}
		else if (m >= 2 * timeDown)
		{
			throwableObject = throwableObject_3;
		}
	}

	void ChangeColor()
    {
		
		float k  = Time.time - m;
		if (k < timeDown)
		{
			colorEffect.color = Color.yellow;
		}
		else if (k >= timeDown && k < 2 * timeDown)
		{
			colorEffect.color = Color.green;

			if (step == 1)
			{
				audio.SetSound(4, 0.5f, false);

				step++;
			}
		}
		else if (k >= 2 * timeDown)
		{
			colorEffect.color = Color.white;

			if (step == 2)
			{
				audio.SetSound(5, 0.5f, true);

				step++;
			}
		}
	}

	public void DoDashDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				
			}
		}
	}
}
