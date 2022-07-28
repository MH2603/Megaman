using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_move : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;

	public float dame = 1;

	Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        if( gameObject.name != "bullet_1(Clone)") anima = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if ( !hasHit)
		GetComponent<Rigidbody2D>().velocity = direction * speed;


		Vector3 m = new Vector3(direction.x, 1, 1);
		transform.localScale = m;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.SendMessage("ApplyDamage", dame);

			StartCoroutine(DestroyBullet());

		}else if (collision.gameObject.tag == "Ground" ) StartCoroutine(DestroyBullet());



		//else if (collision.gameObject.tag != "Player")
		//{
		//	Destroy(gameObject);
		//}
	}


	IEnumerator DestroyBullet()
    {
		if( gameObject.name == "bullet_1(Clone)") Destroy(gameObject);
        else
        {
			speed = 0;
			anima.SetBool("destroy", true);

			yield return new WaitForSeconds(0.4f);
			Destroy(gameObject);
		}

    }

}
