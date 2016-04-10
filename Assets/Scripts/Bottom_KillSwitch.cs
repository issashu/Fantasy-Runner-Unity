using UnityEngine;
using System.Collections;

public class Bottom_KillSwitch : MonoBehaviour 
{

	private GameObject Player;
	// Use this for initialization
	void Start () 
	{

		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () 
	{

		transform.position = new Vector3 (Player.transform.position.x, -10f, transform.position.z);

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Player.GetComponent<PlayerHealth> ().Die ();

		}              
	}
}
