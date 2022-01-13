using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
	public AudioSource blockSound;

	[SerializeField] private Transform player;
	[SerializeField] private Transform respawnPoint;

	private bool collisionOccurred = false;


	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Player" && !collisionOccurred) //If the object that collided with this block is the player...
		{
			//Play the collision sound effect, subtract the player's health, and return the player to the starting position.
			blockSound.Play();
			StartCoroutine(blockHit());
			collisionOccurred = true;
		}
		collisionOccurred = false;


	}

	IEnumerator blockHit()
	{
		HealthSystem.health--;
		yield return new WaitForSeconds(0);
		player.transform.position = respawnPoint.transform.position;
	}
}
