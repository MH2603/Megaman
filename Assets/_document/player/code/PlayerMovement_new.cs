using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_new : MonoBehaviour {

	public CharacterController2D_new controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	float startTime;
	//bool dashAxis = false;
	
	void Start()
    {
		startTime = Time.time + 3f;
    }



	// Update is called once per frame
	void Update () {


		if(startTime < Time.time)
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (Input.GetKeyDown(KeyCode.W))
			{
				jump = true;
			}

			if (Input.GetKeyDown(KeyCode.K))
			{
				dash = true;
			}
		}
		

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
}
