using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
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
	}


}
