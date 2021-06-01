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

	public GameObject[] levels;

	[Space(20)]
	[Header("ADMIN ZONE")]
	public bool customLevel; //custom level counter
	public int customLevelNum; // custom level counter
	public int maxAddedLevelCounter; // oyuna eklenen maksimum level sayısı
	public int minRandomLevelPoint; // randomize işlemi için başlangıç levelini gösterir
	public int maxRandomLevelPoint; // randomize işlemi için bitiş levelini gösterir
	[Space(10)]

	[Header("CONST")]
	public int activeLevel; // oyundaki aktif leveli gösterir
	public int tmpActiveLevel; // level dizisindeki aktif level dizisini gösterir
	private void Awake()
	{
		instance = this;
	}
	private void Start()
	{
		Application.targetFrameRate = 300;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if (!PlayerPrefs.HasKey("LevelCounter"))
		{
			PlayerPrefs.SetInt("LevelCounter", 0);
			PlayerPrefs.Save();
		}

		if (customLevel) activeLevel = customLevelNum - 1;
		else activeLevel = PlayerPrefs.GetInt("LevelCounter");
		tmpActiveLevel = (activeLevel >= maxAddedLevelCounter) ? tmpActiveLevel = Random.Range(minRandomLevelPoint, maxRandomLevelPoint) : activeLevel;

		levels[tmpActiveLevel].SetActive(true);
	}
	public void OnGameStart()
	{
		isGameOn = true;
		tmpActiveLevel = (activeLevel >= maxAddedLevelCounter) ? tmpActiveLevel = Random.Range(minRandomLevelPoint, maxRandomLevelPoint) : activeLevel;
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
		PlayerPrefs.SetInt("LevelCounter", activeLevel + 1);
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
