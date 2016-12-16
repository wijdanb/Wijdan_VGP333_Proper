using UnityEngine;
using System.Collections;

public class DetectControlMethod : MonoBehaviour {

	public PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Detect mouse input
		if (Input.GetMouseButton (0)||Input.GetMouseButton(1)||Input.GetMouseButton(2)) 
		{
			player.useController = false;
		}

		if(Input.GetAxisRaw("Mouse X") != 0.0f ||Input.GetAxisRaw("Mouse Y")!= 0.0f) //if there is not any movement happening in the left or right 
		{
			player.useController = false;
		}

		//Detect Controller Input

		if (Input.GetAxisRaw ("RHorizontal") != 0.0f || Input.GetAxisRaw ("RVertical") != 0.0f) 
		{
			player.useController = true;
		}

		if(Input.GetKey(KeyCode.JoystickButton0) ||
			(Input.GetKey(KeyCode.JoystickButton1)) ||
			(Input.GetKey(KeyCode.JoystickButton2))||
			(Input.GetKey(KeyCode.JoystickButton3))||
			(Input.GetKey(KeyCode.JoystickButton4))||
			(Input.GetKey(KeyCode.JoystickButton5))||
			(Input.GetKey(KeyCode.JoystickButton6))||
			(Input.GetKey(KeyCode.JoystickButton7))||
			(Input.GetKey(KeyCode.JoystickButton8))||
			(Input.GetKey(KeyCode.JoystickButton9)) ||
			(Input.GetKey(KeyCode.JoystickButton10))
		)//Checks buttons that are being pressed by controller
		{
			player.useController = true;
		}
	}

}
