﻿using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler[] theObjectPools;

    private float platformWidth;

   // public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    private float minHight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

	public float CurrentScore;
	float TimeSinceCheckpoint;

	public GameObject Checkpointplatform;

	// Use this for initialization
	void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        minHight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        platformWidths = new float[theObjectPools.Length];
        for(int i=0;i<theObjectPools.Length;i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
		Checkpointplatform = GameObject.FindGameObjectWithTag("Checkpoint");
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		TimeSinceCheckpoint += Time.deltaTime;
        

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)//This line is not mandatory, since the camera is following the player
            { heightChange = maxHeight; }
            else if(heightChange<minHight)
            { heightChange = minHight; }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2)+ distanceBetween , heightChange, transform.position.z);
		   // Debug.Log(platformWidths[platformSelector]);
           // Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, thePlatforms[platformSelector].transform.rotation);

			if (TimeSinceCheckpoint >= 20) 
			{
				Checkpointplatform.transform.position = GameObject.Find("PlatformGenerator").GetComponent<Transform>().position;
				TimeSinceCheckpoint = 0;
				transform.position = new Vector3(transform.position.x +
					(platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
			}

			else
			{
				GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            	newPlatform.transform.position = transform.position;
            	//newPlatform.transform.rotation = transform.rotation;
				if(newPlatform.CompareTag("FallingPlatform"))
					{
						newPlatform.GetComponent<Rigidbody2D>().isKinematic= true;
						newPlatform.GetComponent<FallingPlatform>().contact = false;
						//newPlatform.GetComponent<Collider2D>().isTrigger=false;
					}
				newPlatform.SetActive(true);
            	transform.position = new Vector3(transform.position.x +
				(platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
			}
        }
	
	}
}
