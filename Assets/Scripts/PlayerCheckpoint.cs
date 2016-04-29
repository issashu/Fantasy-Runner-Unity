using UnityEngine;
using System.Collections;

public class PlayerCheckpoint : MonoBehaviour
{
    public Transform platformCheckpointSpawner;
    public Vector3 platformCheckpointStartPoint;

    public Transform playerSpawner;
    public Vector3 playerStartPoint;

    public Transform wallSpawner;
    public Vector3 wallStartPoint;

    public Transform generatorSpawner;
    public Vector3 generatorStartPoint;

    public Transform destroyerSpawner;
    public Vector3 destroyerStartPoint;

    public Transform platformgeneratorSpawner;
    public Vector3 platformgeneratorStartPoint;

    public Transform backgroundgeneratorSpawner;
    public Vector3 backgroundgeneratorStartPoint;

    public GameObject Platformgenerator;

    // Use this for initialization
    void Start()
    {
        platformCheckpointStartPoint = platformCheckpointSpawner.position;
        playerStartPoint = playerSpawner.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            SaveCheckpoint();
        }
    }

    public void RestartCheckpoint()
    {
        StartCoroutine("CheckpointRes");
    }

    public IEnumerator CheckpointRes()
    {
        yield return new WaitForSeconds(0.0f);
        playerSpawner.position = playerStartPoint;
        platformCheckpointSpawner.position = platformCheckpointStartPoint;
        wallSpawner.position = new Vector2(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x - 10f, 0f);
        //generatorSpawner.position = generatorStartPoint;
        //destroyerSpawner.position = destroyerStartPoint;
        platformgeneratorSpawner.position = new Vector2(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x + 5f, 0f);
        backgroundgeneratorSpawner.position = new Vector2(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x - 15f, 0f);
        //Debug.Log ("Position restored" + platformgeneratorStartPoint);
        //Platformgenerator.SetActive (true);
        foreach (GameObject Platform in GameObject.FindGameObjectsWithTag("Platforms"))
        {
            Platform.SetActive(false);
        }
        foreach (GameObject FallPlatform in GameObject.FindGameObjectsWithTag("FallingPlatform"))
        {
            FallPlatform.SetActive(false);
        }
        foreach (GameObject BG in GameObject.FindGameObjectsWithTag("Background"))
        {
            BG.SetActive(false);
        }

    }

    public void SaveCheckpoint()
    {
        StartCoroutine("CheckpointSave");
    }

    public IEnumerator CheckpointSave()
    {
        yield return new WaitForSeconds(0.0f);
        platformCheckpointStartPoint = platformCheckpointSpawner.position;
        playerStartPoint = playerSpawner.position;
        wallStartPoint = wallSpawner.position;
        generatorStartPoint = generatorSpawner.position;
        destroyerStartPoint = destroyerSpawner.position;
        platformgeneratorStartPoint = platformgeneratorSpawner.position;
        backgroundgeneratorStartPoint = backgroundgeneratorSpawner.position;
        //Debug.Log("Position saved" + platformgeneratorStartPoint);
        this.GetComponentInChildren<ParticleSystem>().Play();

    }
}
