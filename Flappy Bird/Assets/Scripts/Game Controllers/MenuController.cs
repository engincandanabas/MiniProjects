using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public static MenuController instance;

	[SerializeField]
	private GameObject[] birds;

	private bool isGreenBirdUnlocked, isRedBirdUnlocked;

	[SerializeField]
	private Animator notificationAnim;
	
	[SerializeField]
	private Text notificationText;
		
	void Awake() {
		MakeInstance();
	}

	void Start() {
		birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		CheckIfBirdsAreUnlocked ();
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void CheckIfBirdsAreUnlocked() {
		if (GameController.instance.IsRedBirdUnlocked () == 1) {
			isRedBirdUnlocked = true;
		}

		if (GameController.instance.IsGreenBirdUnlocked () == 1) {
			isGreenBirdUnlocked = true;
		}
	}

	public void PlayGame() {
		SceneFader.instance.FadeIn ("Gameplay");
	}

	public void ConnectOnGooglePlayGames() {
		LeaderboardsController.instance.ConnectOrDisconnectOnGooglePlayGames ();
	}

	public void OpenLeaderboardsScoreUI() {
		LeaderboardsController.instance.OpenLeaderboardsScore ();
	}

	
	public void ChangeBird() {

		if (GameController.instance.GetSelectedBird () == 0) {

			if (isGreenBirdUnlocked) {
				birds [0].SetActive (false);
				GameController.instance.SetSelectedBird (1);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);
			}

		} else if (GameController.instance.GetSelectedBird () == 1) {

			if (isRedBirdUnlocked) {

				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (2);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);

			} else {

				birds [1].SetActive (false);
				GameController.instance.SetSelectedBird (0);
				birds [GameController.instance.GetSelectedBird ()].SetActive (true);

			}

		} else if (GameController.instance.GetSelectedBird () == 2) {
			birds [2].SetActive (false);
			GameController.instance.SetSelectedBird (0);
			birds [GameController.instance.GetSelectedBird ()].SetActive (true);
		}

	}

	public void NotificationMessage(string message) {
		StartCoroutine (AnimateNotificationPanel(message));
	}

	IEnumerator AnimateNotificationPanel(string message) {
		notificationAnim.Play("SlideIn");
		notificationText.text = message;
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(2f));
		notificationAnim.Play("SlideOut");
	}

	
} // class































































