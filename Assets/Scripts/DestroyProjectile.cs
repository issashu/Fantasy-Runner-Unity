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
	
	}
}
