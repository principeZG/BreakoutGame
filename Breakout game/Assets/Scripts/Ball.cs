using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour {

	//Configuration params
	[SerializeField] private Paddle paddle1;
	[SerializeField] private float xPush = 2f, yPush = 15f;
	[SerializeField] private AudioClip[] ballSounds;

	// state
	private Vector2 paddleToBallVector;
	private bool hasStarted = false;

	// Cached component references
	private AudioSource myAudioSource;

	// Use this for initialization
	void Start ()
	{
		paddleToBallVector = transform.position - paddle1.transform.position;
		myAudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted)
		{
			LockBallToPaddle();
			LaunchOnClick();
		}
	}

	private void LaunchOnClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			hasStarted = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
		}
	}

	private void LockBallToPaddle()
	{
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (hasStarted)
		{
			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
			myAudioSource.PlayOneShot(clip);
		}
	}   
}
