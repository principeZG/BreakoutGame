using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Block : MonoBehaviour {

	// Configuration parameters
	[SerializeField] private AudioClip _breakSound;
	[SerializeField] private GameObject _blockVfx;

	// Cached reference
	private Level _level;
	private GameSession _gameSession;

	private void Start()
	{
		_level = FindObjectOfType<Level>();
		_level.CountBreakableBlocks();
		_gameSession = FindObjectOfType<GameSession>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		DestroyBlock();
		AddPoints();
	}

	private void DestroyBlock()
	{
		BlockDestroyedSfx();
		BlockDestroyedVfx();
		Destroy(gameObject);
		_level.BlockDestroyed();
	}

	private void BlockDestroyedSfx()
	{
		var cameraPos = Camera.main.transform.position;
		_gameSession = FindObjectOfType<GameSession>();
		AudioSource.PlayClipAtPoint(_breakSound, cameraPos);
	}

	private void AddPoints()
	{
		_gameSession.AddPoints();
	}

	private void BlockDestroyedVfx()
	{
		GameObject sparkles = Instantiate(_blockVfx, transform.position, transform.rotation);
		Destroy(sparkles,2f);    
	}
}
