using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

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

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer(damageToGive);
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Enemy") 
		{
			Physics.IgnoreCollision (gameObject.GetComponent<Collider> (), other.gameObject.GetComponent<Collider> ());
		}

		if (other.gameObject.tag == "Sword") 
		{
			//Physics.IgnoreCollision (gameObject.GetComponent<Collider> (), other.gameObject.GetComponent<Collider> ());
			//gameObject.transform.forward

			Vector3 Direction = Vector3.Normalize (other.gameObject.transform.position - gameObject.transform.position);

			gameObject.transform.position.Set (gameObject.GetComponentInParent<EnemyController> ().rb.position.x,gameObject.GetComponentInParent<EnemyController> ().rb.position.y,gameObject.GetComponentInParent<EnemyController> ().rb.position.z);
			Debug.Log ("Sword deflected?");
			//Destroy(gameObject);
		}
	}



}
