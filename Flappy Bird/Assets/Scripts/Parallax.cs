using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float speed = 1;

	SpriteRenderer sr;

	private void Start() {
		sr = GetComponent<SpriteRenderer>();
	}
	
	private void Update() {
		transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);

		if (transform.position.x <= -sr.size.x)
		{
			transform.position = new Vector3(0, transform.position.y);
		}
	}
}
