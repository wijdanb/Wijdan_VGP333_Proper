using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject enemy;
	public float spawnTime = 5.0f;

	public int enemyCount;
	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		enemyCount = 0;

	}


	void Spawn()
	{
		if (enemyCount < 7) {
			int spawnpointindex = Random.Range (0, spawnLocations.Length);

			Instantiate (enemy, spawnLocations [spawnpointindex].position, spawnLocations [spawnpointindex].rotation);
			enemyCount++;
		} else {

		}
	}
	

}
