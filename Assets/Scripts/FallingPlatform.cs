using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float falldelay;
    //private GameObject Platform;
	public bool contact = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Platform = GetComponent<GameObject>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
			contact = true;
            //private SpriteRenderer[] Platform = GetComponentsInChildren<SpriteRenderer>();
            //GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Fall());
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(falldelay);
        rb2d.isKinematic = false;
        //GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
}
