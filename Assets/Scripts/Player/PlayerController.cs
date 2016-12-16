using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator animator;

	TrailRenderer trail;


	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;
	private float tempMoveSpeed;

	private Vector3 targetToLook;

	public GunController gun;

	public bool useController;

	private bool isDashing;
	public bool isSlash;

	public int timer;
	//public enum Direction{Left, Right, Up, Down}

	// Use this for initialization
	void Start () {
		
		//Direction playerDirection;
		//playerDirection = Direction.Up;
		myRigidbody = GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();
		animator = GetComponentInChildren<Animator> ();
		trail = GetComponent<TrailRenderer> ();
		//isSlash = false;
		isSlash = false;
		timer = 100;

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput * moveSpeed;


		//rotate with mouse
		if (!useController) 
		{
			Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition); //creates a line from camera to where mouse is currently in the game screen
			Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
			float rayLength;

			if (groundPlane.Raycast (cameraRay, out rayLength)) 
			{

				targetToLook = cameraRay.GetPoint (rayLength);
				Debug.DrawLine (cameraRay.origin, targetToLook, Color.blue);
				transform.LookAt (new Vector3 (targetToLook.x, transform.position.y, targetToLook.z));
			}

			if (Input.GetMouseButtonDown (0))
			{
				gun.isFiring = true;
			}
			else if (Input.GetMouseButtonUp (0)) 
			{
				gun.isFiring = false;
			}

			if (Input.GetMouseButtonDown (1)) 
			{
//				isSlash = true;
//				animator.SetBool ("isSlash", isSlash);

				//isSlash = true;
				//SlashAttack ();

				//SlashingMove ();
				
				StartCoroutine (SlashingMove ());

				Debug.Log ("Slash RIGHT in attacking is" + isSlash);
			}


			if (Input.GetKeyDown(KeyCode.LeftShift)) 
			{
				trail.enabled = true;
				Dash (cameraRay);
				moveSpeed = tempMoveSpeed;
			}


		


//			animator.SetBool ("isSlash", isSlash);

			//animator.SetBool ("isSlash", isSlash);

//			if (Input.GetKeyDown(KeyCode.LeftShift)&& Input.GetKey(KeyCode.W)) 
//			{
//
//				Dash (Direction.Up);
//				moveSpeed = tempMoveSpeed;
//			}
//
//			if (Input.GetKeyDown(KeyCode.LeftShift)&& Input.GetKey(KeyCode.A)) 
//			{
//
//				Dash (Direction.Left);
//				moveSpeed = tempMoveSpeed;
//			}
//				
//
//			if (Input.GetKeyDown(KeyCode.LeftShift)&& Input.GetKey(KeyCode.S)) 
//			{
//
//				Dash (Direction.Down);
//				moveSpeed = tempMoveSpeed;
//			}
//
//
//			if (Input.GetKeyDown(KeyCode.LeftShift)&& Input.GetKey(KeyCode.D)) 
//			{
//
//				Dash (Direction.Right);
//				moveSpeed = tempMoveSpeed;
//			}
//
			//isSlash = false;
			//animator.SetBool ("isSlash", isSlash);
		}

		//Rotate with controller
		if (useController) 
		{
			
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw ("RHorizontal") + Vector3.forward * -Input.GetAxisRaw ("RVertical");
			if(playerDirection.sqrMagnitude > 0.0f) //checking if the playerdirection vector has any movement, if the player is inputting any direction
			{
				transform.rotation = Quaternion.LookRotation (playerDirection, Vector3.up);

			}

			if (Input.GetKeyDown (KeyCode.Joystick1Button5)) //joystick1button 5 is the RT(right trigger) for xbox controller
				gun.isFiring = true;

			if (Input.GetKeyUp (KeyCode.Joystick1Button5))
				gun.isFiring = false;
		}



//
//
//		if (isSlash) {
//			yield WaitForSeconds(1);
//			StopSlash ();
//		}

	}



	public void SlashAttack()
	{
		//isSlash = true;
		isSlash = true;
		//Debug.Log ("SLASHING");
		animator.SetBool ("isSlash", isSlash);
	//	Debug.Log("Slash right after attacking is" + isSlash);
		//isSlash = false;
	}
		

	public void StopSlash()
	{
		//isSlash = false;
		isSlash = false;
		animator.SetBool ("isSlash", isSlash);
	//	Debug.Log("Slash WAAY after attacking is" + isSlash);
	}
//
	public IEnumerator SlashingMove()
	{
		SlashAttack();
		yield return new WaitForSeconds(1);
		StopSlash();
	}

	//void Dash(Direction dir)
	public void Dash(Ray cam)
	{
		
			//Get forward vector on the ground PLANE!!...
//			Vector3 Target = mainCamera.transform.forward;
//			 Target *= moveSpeed * 2.0f;
//	
//			//Debug.DrawLine( transform.position, Target * 25.0f, Color.red );
//
//			// Apply a force that attempts to reach our target velocity
//			myRigidbody.velocity = Vector3.zero; //Kill all velocity then shoot player forward
//
//			myRigidbody.AddForce(Target, ForceMode.VelocityChange);



		tempMoveSpeed = moveSpeed;
//
		moveSpeed = moveSpeed * 20.0f;
//
//		switch (dir) {
//
//		case Direction.Left:
//			myRigidbody.AddForce (-myRigidbody.transform.right* moveSpeed, ForceMode.VelocityChange);
//			break;
//
//		case Direction.Right:
//			myRigidbody.AddForce (myRigidbody.transform.right* moveSpeed, ForceMode.VelocityChange);
//			break;
//
//		case Direction.Up:
//			myRigidbody.AddForce (myRigidbody.transform.forward* moveSpeed, ForceMode.VelocityChange);
//			break;
//
//		case Direction.Down:
//			myRigidbody.AddForce (-myRigidbody.transform.forward* moveSpeed, ForceMode.VelocityChange);
//			break;
//
//
//
//
//		}



		myRigidbody.AddForce (myRigidbody.transform.forward * moveSpeed, ForceMode.VelocityChange);


			

	}


	void FixedUpdate()
	{

		myRigidbody.velocity = moveVelocity;
		trail.enabled = false;

	}
}
