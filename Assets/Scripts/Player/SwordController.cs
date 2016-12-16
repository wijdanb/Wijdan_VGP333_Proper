using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {


	public int damageToGiveFromSword;
	//EnemyHealthManager killCount;
	//private int killScore;


	// Use this for initialization
	void Start () {
		//killScore = 0;
		//killCount = FindObjectOfType<EnemyHealthManager> ();

	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGiveFromSword);
			//other.gameObject.GetComponent<EnemyHealthManager> ().Count++;

		}

	
	}




}