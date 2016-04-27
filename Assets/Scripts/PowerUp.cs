using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    //public GameObject player;
    PlayerMovement pM;
    int Type;

	// Use this for initialization
	void Start () {
        pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Type = (int)Random.Range(1, 3);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") { 

        switch (Type)
        {
            case 1:
                pM.SendMessage("PowerUp", 1);
                break;
            case 2:
                pM.SendMessage("PowerUp", 2);
                break;
            case 3:
                pM.SendMessage("PowerUp", 3);
                break;
        }
            Destroy(this.gameObject);
            }

    }
    // Update is called once per frame
    void Update () {
	
	}
}


