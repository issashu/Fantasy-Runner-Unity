using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour 
{
	//Следните две променливи са за кръвта на противниците. Могат да бъдат променяни директно от инспектора в Юнити (public type)
	public int EnemyMaxHealth;
	public float PointsPerKill;

	int EnemyCurrHealth; //change to private after tests

		// Use this for initialization
	void Start () 
	{
		EnemyCurrHealth = EnemyMaxHealth; //почват играта с пълна кръв
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (EnemyCurrHealth <= 0) 
		{
			Destroy (transform.parent.gameObject); //ако противника умре, го дестройваме
			GameObject.FindGameObjectWithTag ("ScoreControl").GetComponent<ScoreManage> ().ScoreCounter += PointsPerKill;

		}

	}

	public void DealDMG (int Damage) //функция за демидж. Може да се доразвие в зависимост от уменията.
	{
		EnemyCurrHealth -= Damage;
	}

	void OnTriggerEnter2D (Collider2D Fireball)
	{
		if (Fireball.tag == "Spells") 
		{
			DealDMG (GameObject.FindGameObjectWithTag("Spells").GetComponent<FireBall>().FireDamage);
		}
	}
}
