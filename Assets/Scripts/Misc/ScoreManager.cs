using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	EnemyHealthManager enemyKillCount;
	private int killScore;

	public Text t;

	// Use this for initialization
	void Start () {
		killScore = 0;
		enemyKillCount = FindObjectOfType<EnemyHealthManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		killScore = enemyKillCount.Count;
		t.text = killScore.ToString ();
		Debug.Log("Enemy kill count" + killScore);
		//text.(enemyKillCount.killCount);
	
	}
}
