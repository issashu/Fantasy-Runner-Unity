using UnityEngine;
using System.Collections;

public class BackgroundSlowScroll : MonoBehaviour
{
	public float ScrollSpeed;
	public bool isFacingLeft;
	//public float HorAxis;
	public bool AnimateBG;
	public Renderer TextRend;

	// Use this for initialization
	void Start () 
	{
		TextRend = GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		isFacingLeft = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().isFacingLeft;
		AnimateBG = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ().AnimateBG;

		if (AnimateBG) 
		{
			if (isFacingLeft) 
			{
				float offset = Time.time * -ScrollSpeed;
				TextRend.material.mainTextureOffset = new Vector2 (offset, 0f);
			} 
			if (!isFacingLeft) 
			{
				float offset = Time.time * ScrollSpeed;
				TextRend.material.mainTextureOffset = new Vector2 (offset, 0f);
			}
		}

		Debug.Log ("Facing Left:" + isFacingLeft);
		Debug.Log (ScrollSpeed);
		Debug.Log (AnimateBG);
	}
}
