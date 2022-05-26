using UnityEngine;
using System.Collections;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderboardsController : MonoBehaviour {

	public static LeaderboardsController instance;

	private const string LEADERBOARDS_SCORE = "";

	void Awake() {
		MakeSingleton ();
	}

	// Use this for initialization
	void Start () {
//		PlayGamesPlatform.Activate ();
	}

	void OnLevelWasLoaded() {
		ReportScore (GameController.instance.GetHighscore());
	}

	void MakeSingleton() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void ConnectOrDisconnectOnGooglePlayGames() {
		if (Social.localUser.authenticated) {
//			PlayGamesPlatform.Instance.SignOut ();
		} else {
			Social.localUser.Authenticate((bool success) => {

			});
		}
	}

	public void OpenLeaderboardsScore() {
		if (Social.localUser.authenticated) {
//			PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARDS_SCORE);
		}
	}

	void ReportScore(int score) {
		if (Social.localUser.authenticated) {
			Social.ReportScore(score, LEADERBOARDS_SCORE, (bool success) => {
			});
		}
	}



} // class













































