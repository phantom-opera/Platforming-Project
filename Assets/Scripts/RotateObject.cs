using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	float rotSpeed = 60f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World); //Rotates the object continiously 360 degrees.
	}
}
