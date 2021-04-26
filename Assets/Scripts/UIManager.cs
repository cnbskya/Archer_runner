using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public GameObject startGamePanel;
	public GameObject inGameUI;
	public GameObject endGamePanel;
	public GameObject swipePanel;

	private void Awake()
	{
		instance = this;
		startGamePanel.SetActive(true); // BEFORE THE GAME STARTS
	}
	
	public void StartedScreenUI()
	{
		startGamePanel.SetActive(false);
		inGameUI.SetActive(true);
	}

	public IEnumerator FinishScreenUI()
	{
		yield return new WaitForSeconds(1.6f);
		inGameUI.SetActive(false);
		swipePanel.SetActive(true);
		endGamePanel.SetActive(true);
	}

	public void RestartGame()
	{
		DOTween.KillAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
}
