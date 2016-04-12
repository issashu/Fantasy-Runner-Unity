using UnityEngine;
using System.Collections;

public class CharacterDMGDealer : MonoBehaviour {

	public int DMG; //Това е публична променлива и може да се наглася в Юнити. Ползва се по-долу в ONCollisionEnter2D за да правим демидж на героя.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //This function deals with detecting the collision between the Player 
    //and the enemy bullet.
    //It can be called within the bullet code to do damage
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<ChracterHealthmanager>().DealDMG (DMG); //На база колко демидж има нагласен дадения моб, прави демидж на героя ни
		}
	}
}
