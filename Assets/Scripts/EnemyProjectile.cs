using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour 
{

	public float ProjectileSpeed;
	public float Damage;

	Rigidbody2D ProjectileRB;
	GameObject EnemyShooter;
	GameObject Player;



	void Awake () 
	{
		//Initialising all variables
		EnemyShooter = GameObject.FindGameObjectWithTag("Shooter");
		Player = GameObject.FindGameObjectWithTag ("Player");
		ProjectileRB = GetComponent<Rigidbody2D> ();

		if (EnemyShooter.GetComponent<Shooting>().FacingRight)
		{
			transform.localScale = new Vector2 (-1, 1);
			ProjectileRB.AddForce (new Vector2 (1, 0) * ProjectileSpeed, ForceMode2D.Impulse);
		}
		else if (!EnemyShooter.GetComponent<Shooting>().FacingRight)
		{
			transform.localScale = new Vector2 (1, 1);
			ProjectileRB.AddForce (new Vector2 (-1, 0) * ProjectileSpeed, ForceMode2D.Impulse);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //You shall NOT PAAAAS!
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Player.GetComponent<PlayerHealth> ().TakeDamage (Damage);
			Destroy (gameObject, 0f);
		}
	}
}
