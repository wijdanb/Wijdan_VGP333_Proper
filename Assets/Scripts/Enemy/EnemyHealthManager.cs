using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {


	public int health;
	private int currentHealth;

	public int Count;


	public float flashLength;
	private float flashCounter;

	private Renderer rend;
	private Color storedColor;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		storedColor = rend.material.GetColor ("_Color");
		currentHealth = health;
		Count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			
			Destroy (gameObject);
			Count++;

		}

		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;

		}

		if (flashCounter <= 0) 
		{
			rend.material.SetColor ("_Color", storedColor);
		}
	}

	public void HurtEnemy(int damage)
	{
		//Debug.Log ("Damage sword:" + damage);
		currentHealth -= damage;
		//Debug.Log ("Enemy Health" + currentHealth);
		flashCounter = flashLength;
		rend.material.SetColor ("_Color", Color.red);
		if (currentHealth <= 0) {

			Destroy (gameObject);
			Count++;

		}
	}
}
