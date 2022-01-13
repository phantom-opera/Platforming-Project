using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
	public AudioSource collectSound;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") //If the player collides with this object...
		{
			//Play the collection sound effect, update the player's score, and then destroy the coin.
			collectSound.Play();
			ScoringSystem.score++;
			Destroy(gameObject);
		}
	}
}
