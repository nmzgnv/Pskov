using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using CameraFading;

public class GameManager : MonoBehaviour
{
	public static GameManager GM { get; set; }
	public bool IsGamePaused { get; private set; }

	[SerializeField]
	private List<string> scenes = new List<string>();
	private int currentScene = -1;

	void Awake()
	{

		if (GM != null && GM != this)
		{
			Destroy(GM);
		}

		GM = this;

		DontDestroyOnLoad(gameObject);
	}

	public void PauseGame()
	{
		if (!IsGamePaused)
		{
			Time.timeScale = 0;
			IsGamePaused = true;
		}
		else
			ContinueGame();
	}

	public void ContinueGame()
	{
		Time.timeScale = 1;
		IsGamePaused = false;
	}

	private void loadFinal()
	{
		SceneManager.LoadScene("FinalScene");
	}

	public void restartScene()
	{
		Time.timeScale = 1;
		var _currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(_currentScene.name);
	}

	public void showMenu()
	{

	}

	public void nextScene()
	{
		++currentScene;
		try
		{
			CameraFade.Out(() =>
			{
				SceneManager.LoadScene(scenes[currentScene]);
				CameraFade.In(2f);
			}
			, 2f);
			SceneManager.LoadScene(scenes[currentScene]);
		}
		catch (ArgumentOutOfRangeException exc)
		{
			Debug.LogError("А сценки то кончились");
			loadFinal();
		}
	}

	public void LoadFirstScene()
	{
		SceneManager.LoadScene("2.5D-First");
	}
}
