using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivate : MonoBehaviour
{
	public AudioSource trapSound;

	[SerializeField] private Transform player;
	[SerializeField] private Transform respawnPoint;
	private bool collisionOccurred = false;
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}


	private void OnTriggerEnter(Collider collision) //If the player collides with this object a sound effect is played and the 'trapActivated' coroutine starts.
	{
		if (collision.tag == "Player" && !collisionOccurred)
		{
			trapSound.Play();
			StartCoroutine(trapActivated());
		}
		collisionOccurred = false;

	}

	IEnumerator trapActivated() //Subtracts the player's health, stops them from moving for 2 seconds, then teleports them to the starting position.
	{
		animator.SetBool("isActivated", true);
		HealthSystem.health--;
		GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = false;
		yield return new WaitForSeconds(2);
		animator.SetBool("isActivated", false);
		player.transform.position = respawnPoint.transform.position;
		GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = true;
	}
	

}
