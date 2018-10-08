using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = 3;
	
	// Update is called once per frame
	void Update () {
		transform.position = 
			new Vector3(transform.position.x - speed * Time.deltaTime,
			transform.position.y);
		if (transform.position.x <= -10)
		{
			Destroy(gameObject);	
		}
	}
}
