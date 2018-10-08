using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float jumpPower = 5;
	public Text scoreText;

	Rigidbody2D rb2d;
	Animator anim;
	bool isDead = false;

	public AudioClip jumpClip;
	public AudioClip scoreClip;
	public AudioClip deadClip;

	public GameObject gameover;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		Time.timeScale = 1.0f;
		if (Input.GetKeyDown(KeyCode.Space) && !isDead)	{
			Jump();
			
		}
		else if (Input.GetKeyDown(KeyCode.Space) && isDead) {
			SceneManager.LoadScene(0);
					
		}
	}

	void Jump()
	{
		rb2d.velocity = new Vector2(0, jumpPower);
		AudioManager.instance.PlaySfx(jumpClip);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isDead)
			return;
		AudioManager.instance.PlaySfx(scoreClip);
		GameManager.instance.score += 1;
		GameManager.instance.scoreText.text = "Score : " + GameManager.instance.score;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		gameover.SetActive(true);
		isDead = true;
		anim.SetTrigger("Dead");
		Time.timeScale = 0;
		AudioManager.instance.PlaySfx(deadClip);
	
	}

}
