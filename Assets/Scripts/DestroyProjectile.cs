using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	public float ProjectileTimer;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, ProjectileTimer);
	}
	
	// Update is called once per frame
	void Update () {


        //public GameObject test;
       // transform.position.x = new Vector2(0f, 0f);
	}
}
