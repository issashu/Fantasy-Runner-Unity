using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{

	public GameObject Bullet;
	public float ShootPeriod;
	public Transform Gun;
	public int ChancetoShoot;
	float ShootTimer;
	public bool FacingRight;

	Animator ShootAnim;



	// Use this for initialization
	void Start () 
	{
		ShootAnim = GetComponent<Animator> ();
		ShootTimer=0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerStay2D (Collider2D other)
	{
		CheckEnemyScale2D (other);
		//Debug.Log ("Is in");
		if (other.tag == "Player" && ShootTimer < Time.time) 
		{
			ShootTimer = Time.time + ShootPeriod;   // Може да се направи да стреля по-рядко или на рандом интервали от следващия ред
			if (Random.Range (0, 5) >= ChancetoShoot) 
			{
				ShootAnim.SetTrigger ("PIR");
				Instantiate (Bullet, Gun.position, Quaternion.identity); // Тук анимацията се бъгва поради някаква причина и не се пуска
			}
		}
	}


	void CheckEnemyScale2D (Collider2D other) // Завърта противника спрямо героя. В случая не е нужно, защото е топка, но работи. Въпреки това си личи по текстурата, че се е завъртяла
	{
		if (other.tag == "Player") 
		{
			if (other.transform.position.x > transform.position.x) 
			{
				transform.localScale = new Vector2 (-1, 1);
				//Debug.Log ("Right");
				FacingRight = true;

			} 

			if (other.transform.position.x < transform.position.x) 
			{
				transform.localScale = new Vector2 (1, 1);
				//Debug.Log ("left");
				FacingRight = false;
			}

		}
	}
}
