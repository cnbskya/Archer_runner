using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public GameObject startGamePanel;
	//public GameObject topUI;
	//public GameObject endGamePanel;

	private void Awake()
	{
		instance = this;
		startGamePanel.SetActive(true); // BEFORE THE GAME STARTS
	}
	
	public void StartedScreenUI()
	{
		//startGamePanel.SetActive(false);
		//topUI.SetActive(true);
	}
	
	public void FinishScreenUI()
	{
		//topUI.SetActive(false);
		//endGamePanel.SetActive(true);
	}

	public void RestartGame()
	{
		DOTween.KillAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
}
