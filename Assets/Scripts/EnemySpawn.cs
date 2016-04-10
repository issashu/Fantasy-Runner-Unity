using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] enemies;
    private int enemySelector;

	// Use this for initialization
	void Start () {
        /*enemySelector = Random.Range(0, enemies.Length);
        GameObject newEnemy = enemies[enemySelector];
        if (newEnemy.CompareTag("Pusher") || newEnemy.CompareTag("Shooter"))
        {
            Instantiate(enemies[enemySelector], transform.position, transform.rotation);
        }*/

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        enemySelector = Random.Range(0, enemies.Length);
        GameObject newEnemy = enemies[enemySelector];
        
        if(newEnemy.CompareTag("Pusher") || newEnemy.CompareTag("Shooter"))
        {
            Instantiate(enemies[enemySelector], transform.position, transform.rotation);
        }
    }
}
