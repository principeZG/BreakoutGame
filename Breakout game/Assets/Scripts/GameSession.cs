using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

	// Configuration parameters
	[Range(0.1f,10f)] [SerializeField] private float _gameSpeed = 1f;
	[SerializeField] private int brickValue = 10;
	[SerializeField] private TextMeshProUGUI scoreText;

	// state variables
	[SerializeField] int _playerScore = 0;
	private static GameSession _gameStatus = null;

	void Awake() // Singleton Pattern Implementation
	{
		if (_gameStatus == null)
		{
			_gameStatus = this;
		}
		else if (_gameStatus != this)
		{
			Destroy(gameObject);
		}
		else
		{
		    DontDestroyOnLoad(gameObject);
        }
	}

	void Start()
	{
		scoreText.text = _playerScore.ToString();
	}


	// Update is called once per frame
	void Update ()
	{
		Time.timeScale = _gameSpeed;
	}

	public void AddPoints()
	{
		_playerScore += brickValue;
		scoreText.text = _playerScore.ToString();
	}

    public void GameOver()
    {
        Destroy(gameObject);
    }
}
