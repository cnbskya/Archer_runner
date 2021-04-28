using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject touchPanel;
	public GameObject swipePanel;
	public bool isGameOn;
	private void Awake()
	{
		instance = this;
	}
	public void OnGameStart()
	{
		isGameOn = true;
		UIManager.instance.StartedScreenUI();
	}

	public void FailOnGameFinish()
	{
		isGameOn = false;
		touchPanel.SetActive(false);
		StartCoroutine(UIManager.instance.FailFinishScreenUI());
	}
	public void SuccessOnGameFinish()
	{
		isGameOn = false;
		touchPanel.SetActive(false);
		StartCoroutine(UIManager.instance.SuccessFinishScreenUI());
	}

	public void İsSwipePanelActive(bool isSwipe)
	{
		if (isSwipe)
		{
			swipePanel.SetActive(isSwipe);
			touchPanel.SetActive(!isSwipe);
		}
		else
		{
			swipePanel.SetActive(!isSwipe);
			touchPanel.SetActive(isSwipe);
		}
	}

	public void RestartGame()
	{
		Debug.Log("SampleScene Restart");
		SceneManager.LoadScene("SampleScene");
	}
}
