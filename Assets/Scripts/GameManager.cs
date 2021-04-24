using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void OnGameFinish()
	{
		isGameOn = false;
		touchPanel.SetActive(false);
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
}
