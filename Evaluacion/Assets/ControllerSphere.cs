using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class ControllerSphere : MonoBehaviour {
    public static float seconds;
    public static bool dead;

	public float walkSpeed = 8f;
	public float speed = 6.0F;
	public float gravity = 20.0F;
	private Quaternion targetRotation;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
    public float jumpSpeed = 8.0F;
    public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F;

    public bool onMenu;

	// Use this for initialization
	void Start () {
        seconds = 0;
        if (onMenu)
            gravity = 0;
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateMovement();
        seconds += Time.deltaTime;

        if (Input.GetButtonDown("cambio"))
            restartGame();
	}
    void restartGame()
    {
        seconds = 0;
        Application.LoadLevel(0);
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
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

		moveDirection.y -= gravity * Time.deltaTime;
        if (!onMenu)
         controller.Move(moveDirection * Time.deltaTime);
		
		float rotationX = transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
		float aux = transform.eulerAngles.x;
		
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		
		
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		
		transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
}
