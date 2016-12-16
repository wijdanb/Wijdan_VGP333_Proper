using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Rigidbody rb;
	public float movespeed;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		player = FindObjectOfType<PlayerController> ();
	}

	void FixedUpdate(){

		rb.velocity = (transform.forward * movespeed);
	}


	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
	}
}
