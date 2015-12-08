using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class ControllerSphere : MonoBehaviour {

	public float walkSpeed = 8f;
	public float speed = 6.0F;
	public float gravity = 20.0F;
	private Quaternion targetRotation;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;

	public GameObject[] cubes;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateMovement();
		if (Input.GetButtonDown ("cambio"))
			changePositions ();
	}
	void changePositions() {
		Vector3 aux = cubes [0].transform.position;

		for (int i = 1; i < cubes.Length; i++) {
			cubes[i - 1].transform.position = cubes[i].transform.position;
		}
		cubes [cubes.Length - 1].transform.position = aux;
	
	}
	void updateMovement()
	{
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		
		float rotationX = transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
		float aux = transform.eulerAngles.x;
		
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		
		
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		
		transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
}
