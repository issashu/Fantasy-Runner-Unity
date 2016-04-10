using UnityEngine;
using System.Collections;

public class CameraConrol : MonoBehaviour {

    /* public PlayerMovement thePlayer;


     private Vector3 lastPlayerPos;
     private Vector3 newPlayerPos;

     // Use this for initialization*/
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

	void Start () {
        /*thePlayer = FindObjectOfType<PlayerMovement>();
        lastPlayerPos = thePlayer.transform.position;*/
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /* newPlayerPos = thePlayer.transform.position;

         transform.position = Vector3.Lerp(lastPlayerPos, newPlayerPos,Time.deltaTime);
         transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
         lastPlayerPos = newPlayerPos;*/
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y+0.5f, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX+0.4f, posY-0.2f, transform.position.z);
    }
}
