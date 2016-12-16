using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;

	public float lifeTime;

	public int damageToGive;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector3.forward * speed* Time.deltaTime);//timing it by time.deltatime since update will randomly update on any random second or millisecond

		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer(damageToGive);
			Destroy (gameObject);
		}

	}




}
