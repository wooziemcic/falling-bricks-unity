using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 15f;
	public float mapWidth = 5f;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	//if lots of movement are there it is better to run in update then control in fixed update but here only horizontal movements are there so fixed update is only used

	void FixedUpdate()
	{
		float x = Input.GetAxis ("Horizontal") *Time.fixedDeltaTime*speed;

		Vector2 newPosition = rb.position + Vector2.right * x;

		newPosition.x = Mathf.Clamp (newPosition.x, -mapWidth, mapWidth);

		rb.MovePosition (newPosition); //Vector2 is used to make it 2d movement, multiplying x with it makes it move to both left and right direction
	}

	void OnCollisionEnter2D()
	{
		//Debug.Log("Hit!");
		Score.scoreValue = 0;
		FindObjectOfType<GameManager>().EndGame();
	}
}
