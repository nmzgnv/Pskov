using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteraction : MonoBehaviour
{
	[SerializeField]
	private GameObject _pausePanel;
    private GameManager _gameManager;
	private AudioSource _clickUISound;

	private void Start()
	{
		_pausePanel.SetActive(false);
		_gameManager = FindObjectOfType<GameManager>();
	}


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_gameManager.PauseGame();
			_pausePanel.SetActive(_gameManager.IsGamePaused);
		}
	}

	public void OnContinueButtonClicked()
	{
		_gameManager.ContinueGame();
		_pausePanel.SetActive(false);
	}

	public void OnPlayAgainButtonClicked()
	{
		_gameManager.restartScene();
	}
}
