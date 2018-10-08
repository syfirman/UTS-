using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject obstacle;
	public float timeToSpawn = 2;

	float timer = 0;

	//60 fps
	//Time.deltaTime = 1 / 60 = 0.0167
	private void Update()
	{
		//sama dengan timer = timer + Time.deltaTime;
		timer += Time.deltaTime;

		if (timer >= timeToSpawn) {
			float randomY = Random.Range(-7.6f, -4.3f);

			Instantiate(obstacle, new Vector3(7.5f, randomY), Quaternion.identity);
			timer = 0;
		}
	}
}
