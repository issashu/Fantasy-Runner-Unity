using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject BackgroundTile;
    public Transform BackgroundGenPoint;
    public ObjectPooler[] BackgroundPooler;

    private float TileWidght;
    private int TileSelector;
    private float[] TileWidths;

    public float minHight;
    public Transform minHeightPoint;
    public float maxHeight;
    public Transform maxHeightPoint;

    // Use this for initialization
    void Start ()
    {
        minHight = minHeightPoint.position.y;
        maxHeight = minHeightPoint.position.y;

        TileWidths = new float[BackgroundPooler.Length];
        for (int i = 0; i < TileWidths.Length; i++)
        {
            TileWidths[i] = BackgroundPooler[i].pooledObject.GetComponent<Renderer>().bounds.size.x;
        }

    }
	
	// Update is called once per frame
	void Update()
    {
        if (transform.position.x < BackgroundGenPoint.position.x)
        {
            TileSelector = Random.Range(0, BackgroundPooler.Length);
            transform.position = new Vector2(transform.position.x + TileWidths[TileSelector], transform.position.y);
            GameObject NewBGTile = BackgroundPooler[TileSelector].GetPooledObject();
            NewBGTile.transform.position = transform.position;
            NewBGTile.SetActive(true);
        }


    }
}
