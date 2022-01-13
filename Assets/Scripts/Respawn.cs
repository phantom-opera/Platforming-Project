using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
	[SerializeField] private Transform respawnPoint;

	private bool collisionOccurred = false;

	private void OnTriggerEnter(Collider collision) //If the player collides with this object they will be sent back to their starting position.
	{
		if (collision.tag == "Player" && !collisionOccurred)
		{
			StartCoroutine(planeHit());
			collisionOccurred = true;
		}
		collisionOccurred = false;
	}

	IEnumerator planeHit()
	{
		yield return new WaitForSeconds(0);
		player.transform.position = respawnPoint.transform.position;
	}
}
