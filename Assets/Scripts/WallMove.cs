using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour 
{

	GameObject Wall;
	Rigidbody2D WallRB;
	public float WSpeed;

	// Use this for initialization
	void Start () 
	{
		WallRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		WallRB.velocity = new Vector2 (WSpeed, 0f);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Die();
			WallRB.velocity = Vector2.zero;
        }
    }

}
