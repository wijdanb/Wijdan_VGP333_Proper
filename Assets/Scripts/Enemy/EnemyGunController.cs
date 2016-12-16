using UnityEngine;
using System.Collections;

public class EnemyGunController : MonoBehaviour {

	public bool isFiring;

	public EnemyBulletController bullet; // this is what we want to use and control 
	public float bulletSpeed;

	public float timeBetweenShots;
	private float shotCounter;

	public Transform firePoint;

	private int bulletPattern;

	// Use this for initialization
	void Start () {

		bulletPattern = Random.Range (1, 5);
		Debug.Log ("bulletpatter : " + bulletPattern);

	}

	// Update is called once per frame
	void Update () 
	{
		
			shotCounter -= Time.deltaTime;
			if (shotCounter <= 0) 
			{
				shotCounter = timeBetweenShots;
				EnemyBulletController newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as EnemyBulletController;
				newBullet.speed = bulletSpeed;
			}
			

	

//		bulletPattern = Random.Range (1, 5);
//		Debug.Log ("bulletpatter : " + bulletPattern);

		switch (bulletPattern)
		{
		case 1:
			Debug.Log ("BulletPattern 1");

			timeBetweenShots = Random.Range (1, 5);
			Debug.Log ("timebetweenshots" + timeBetweenShots);

			bulletSpeed = Random.Range (6, 10);
			Debug.Log ("bulletspeed" + bulletSpeed);

			break;

		case 2:
			Debug.Log ("BulletPattern 2");

			timeBetweenShots = Random.Range (1, 4);
			Debug.Log ("timebetweenshots" + timeBetweenShots);

			bulletSpeed = Random.Range (7, 20);
			Debug.Log ("bulletspeed" + bulletSpeed);


			break;

		case 3:
			Debug.Log ("BulletPattern 3");

			timeBetweenShots = Random.Range (1, 6);
			Debug.Log ("timebetweenshots" + timeBetweenShots);

			bulletSpeed = Random.Range (10, 20);
			Debug.Log ("bulletspeed" + bulletSpeed);

			break;

		case 4:
			Debug.Log ("BulletPattern 4");

			timeBetweenShots = Random.Range (1,2);
			Debug.Log ("timebetweenshots" + timeBetweenShots);

			bulletSpeed = Random.Range (12, 19);
			Debug.Log ("bulletspeed" + bulletSpeed);
			break;


		}
	}


	void SwitchProjectilePattern()
	{
		//have an int variable for pattern
		//every update, randomize the pattern variable
		// have a switch case to determine the pattern for current update
		//depending on each case, change the shot counter and the time between shots-->maybe clamp?
		//maybe instantiate more than 1 bullet for different patterns?



	}

}
