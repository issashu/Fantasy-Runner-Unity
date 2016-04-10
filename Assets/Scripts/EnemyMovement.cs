using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//Enemy position for animations and determening movement direction
	bool FacingRight = false; 

	//Chargin the player
	public float ChargeTime;
	float BeginCharge;
	bool IsCharging;
	Rigidbody2D EnemyRigidBody;
	public float EnemySpeed;
	public float PushVelocity;

	Animator EnemyAnim;


	// Use this for initialization
	void Start () {
		EnemyRigidBody = GetComponent<Rigidbody2D>();
		EnemyAnim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//При навлизане на героя в колайдера на противника, той се засилва и го блъска от платформата
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") // Check if it is the player you are colliding with
		{
			//Check for position of player left or right of the enemy
			if (other.transform.position.x > transform.position.x) 
			{
				transform.localScale = new Vector2 (-1, 1);
				FacingRight = true;

			}

			else if (other.transform.position.x < transform.position.x) 
			{
				transform.localScale = new Vector2 (1, 1);
				FacingRight = false;
			}
			EnemyAnim.SetBool ("Activated", true);
			//IsCharging = true; //Unused for now, useful for checking if enemy is attacking
			BeginCharge = Time.time + ChargeTime; // Player has ChargeTime to react before the enemy attacks. Can be used to time further events  as wells
			//Debug.Log("Triggerenter");

		}
	}

	//Всички евентове, които се случват докато двата тригера се засичат
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") //Check if it is the player you are colliding with
		{ 
			if (BeginCharge < Time.time) // As soon as current time surpasses the amount needed for the enemy to begin attacking
			{
				EnemyAnim.SetBool ("IsCharging", true);
				if (FacingRight) 
					EnemyRigidBody.velocity = new Vector2(PushVelocity,0f);
				//	EnemyRigidBody.AddForce(new Vector2(1,0)*EnemySpeed); //Attack right
				else
					EnemyRigidBody.velocity = new Vector2(-PushVelocity,0f);
				//	EnemyRigidBody.AddForce(new Vector2(-1,0)*EnemySpeed); //Attack left
				//Debug.Log("isIn");
			}
		}
	}

	//Героя най-нагло къса връзката си с противника чрез СМС
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			EnemyAnim.SetBool("Activated", false); 
			EnemyRigidBody.velocity = new Vector2(0f,0f); //we stop the enemy movement the second that a player exits the trigger area
			//Debug.Log("Triggerexit");
		}
	}
}
