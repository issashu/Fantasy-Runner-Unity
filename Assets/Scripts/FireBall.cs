using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
    PlayerMovement SpellBook;

    float LifeTime = 1f;
    Rigidbody2D rb2d;
    float position;

	public int FireDamage;
	public float ManaCost;

	GameObject Enemy;
    
    void Start() 
	{
        SpellBook = GetComponentInParent<PlayerMovement>();
        Vector3 loc = this.transform.localScale;
        loc.x *= SpellBook.pos;
        transform.localScale = loc;
       
        rb2d = GetComponent<Rigidbody2D>();

		ManaCost = 2f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
        LifeTime = 1f;
		ContactPoint2D contact = col.contacts [0];

    }
    // Update is called once per frame
    void FixedUpdate() {
 
        LifeTime -= Time.deltaTime;
        if(LifeTime < 0)
        {
            gameObject.SetActive(false);
            transform.localPosition = Vector3.zero;
            LifeTime = 1f;
        }
	}
}
