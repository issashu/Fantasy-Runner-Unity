using UnityEngine;
using System.Collections;

public class FollowThePlayer : MonoBehaviour {

    public float DistanceFromPlayer;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       Vector2 position = transform.position;
        position.x = player.transform.position.x +DistanceFromPlayer;
        transform.position = position;
	}
}
