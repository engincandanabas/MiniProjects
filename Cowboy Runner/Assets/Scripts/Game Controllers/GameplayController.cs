using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Button restartGameButton;

	[SerializeField]
	private Text scoreText, pauseText;

	private int score;

	void Start () {
		scoreText.text = score + "M";
		StartCoroutine (CountScore());
	}

	IEnumerator CountScore() {
		yield return new WaitForSeconds(0.6f);
		score++;
		scoreText.text = score + "M";
		StartCoroutine (CountScore());
	}

	void OnEnable() {
		PlayerDied.endGame += PlayerDiedEndTheGame;
	}

	void OnDisable() {
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}

	void PlayerDiedEndTheGame() {

		if (!PlayerPrefs.HasKey ("Score")) {
			PlayerPrefs.SetInt("Score", 0);
		} else {
			int highscore = PlayerPrefs.GetInt("Score");

			if(highscore < score) {
				PlayerPrefs.SetInt("Score", score);
			}
		}

		pauseText.text = "Game Over";
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());
		Time.timeScale = 0f;

	}

	public void PauseButton() {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => ResumeGame());
	}

	public void GoToMenu() {
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		Application.LoadLevel ("Gameplay");
	}

} //GameplayController































































