using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
	private Vector3 direction;
	public CharacterController controller;
	public Transform cam;
	Animator animator;

	public float speed = 6;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;
	public float turnSmoothTime = 0.1f;
	public float Jumpforce = 7.0f;
	float turnSmoothVelocity;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	void Start()
    {
		animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update()
	{

		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		controller = GetComponent<CharacterController>();
		controller.center = new Vector3(0, 1, 0);
		bool isSprinting = animator.GetBool("isSprinting");
		float horizontal = Input.GetAxisRaw("Horizontal"); // Takes player input and moves character left or right
		float vertical = Input.GetAxisRaw("Vertical"); // Takes player input and moves character up or down.
		bool runPressed = Input.GetKey("left shift");
		bool jumpPressed = Input.GetKey("space");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		velocity.y += gravity * Time.deltaTime;


		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

			controller.Move(moveDir.normalized * speed * Time.deltaTime);
		}

		if (direction != Vector3.zero) //If the player is moving...
		{
			
			animator.SetBool("isRunning", true);
		}

		else
		{
			animator.SetBool("isRunning", false);
		}

		if ( !isSprinting && (direction != Vector3.zero && runPressed))
		{
			animator.SetBool("isSprinting", true);
			speed = 12f;
		}

		if( isSprinting && (direction == Vector3.zero || !runPressed))
		{
			animator.SetBool("isSprinting", false);
			speed = 6f;
		}

		this.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}


	}


}
