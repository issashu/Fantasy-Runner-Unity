using UnityEngine;
using System.Collections;

public class ChracterHealthmanager : MonoBehaviour {

	//Следните две променливи са за кръвта на героя. Могат да бъдат променяни директно от инспектора в Юнити (public type)
	public int CharMaxHealth;
	private int CharCurrHealth;

	// Use this for initialization
	void Start () 
		{
			CharCurrHealth = CharMaxHealth; //почваме играта с пълна кръв
			
		}
	
	// Update is called once per frame
	void Update () 
		{
	
			if (CharCurrHealth <= 0) 
				{
					gameObject.SetActive (false); //ако героя умре, го деактивираме като обект в Юнити

				}

		}

	public void DealDMG (int Damage) //функция за демидж на героя. Може да се доразвие в зависимост от моба
		{
			CharCurrHealth -= Damage;
		}


	/* Базова функцция за лекуване на героя. Може да се вика при взимане на различни предмети за лекуване.
	public void HealDMG (int Heal)
		{
			CharCurrHealth += Heal;
		}

	Бърза функция за пълно излекуване на героя
	public void HealFULL (int Heal)
		{
			CharCurrHealth = CharMaxHealth;
		}
	*/

}
