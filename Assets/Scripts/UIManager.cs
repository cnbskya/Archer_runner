using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public GameObject startGamePanel;
	public GameObject inGameUI;
	public GameObject endGameFailPanel;
	public GameObject swipePanel;
	public GameObject levelSuccessPanel;

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

	public IEnumerator FailFinishScreenUI()
	{
		yield return new WaitForSeconds(1.6f);
		inGameUI.SetActive(false);
		swipePanel.SetActive(true);
		endGameFailPanel.SetActive(true);
	}
	public IEnumerator SuccessFinishScreenUI()
	{
		yield return new WaitForSeconds(1.6f);
		inGameUI.SetActive(false);
		swipePanel.SetActive(true);
		levelSuccessPanel.SetActive(true);
	}

	public void RestartGame()
	{
		DOTween.KillAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
}
