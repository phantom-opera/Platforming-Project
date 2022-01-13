using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController controller;

	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;


	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	private bool groundedPlayer;

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
		//isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		

		/*if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		*/
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);

		/*if(Input.GetKeyDown("space") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
		}
		*/

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);

		
		if (Input.GetKey("left shift"))
		{
				speed = 20f;
		}
		else
		{
				speed = 12f;
		}

		if (Input.GetKey(KeyCode.C))
		{
			controller.height = 2.0f;
		}

		else
		{
			controller.height = 3.8f;
		}
		

		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && velocity.y < 0)
		{
			velocity.y = 0f;
		}




		// Changes the height position of the player..
		if (Input.GetButtonDown("Jump") && groundedPlayer)
		{
			velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);


	}
}
