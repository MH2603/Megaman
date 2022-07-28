using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
	public float FollowSpeed = 2f;
	public GameObject player;
	public GameObject boss;

	public boss_action action;
	public GameObject[] boneFire;
	public GameObject[] boneLightning;


	public float Y;
	Vector3 posPlayer, posBoss;
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	private Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	private void Update()
	{

		boneFire = GameObject.FindGameObjectsWithTag("boneFire");
		boneLightning = GameObject.FindGameObjectsWithTag("boneLightning");

		

 		if (action.step == 23 && boneFire.Length >= 1 ) posPlayer = boneFire[boneFire.Length - 1].transform.position;
		else if ( action.step == 27 && boneLightning.Length >= 1 ) posPlayer = boneLightning[boneLightning.Length - 1].transform.position;
		else posPlayer = player.transform.position;

		if (action.step == -2) posBoss = posPlayer;
		else posBoss = boss.transform.position;	

		Vector3 newPosition = new Vector3( (posPlayer.x + posBoss.x)/2, (posPlayer.y + posBoss.y)/2 + Y, posPlayer.z ); 
		
		newPosition.z = -10;
		transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);

		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
	}

	public void ShakeCamera()
	{
		originalPos = camTransform.localPosition;
		shakeDuration = 0.2f;
	}


}
