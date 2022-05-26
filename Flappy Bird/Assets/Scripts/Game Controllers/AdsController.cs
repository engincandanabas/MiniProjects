using UnityEngine;
using System.Collections;

public class AdsController : MonoBehaviour {

	public static AdsController instance;

	private const string SKD_KEY = "";

	void Awake() {
		MakeSingleton ();
	}

	// Use this for initialization
	void Start () {
		AppLovin.SetSdkKey (SKD_KEY);
		AppLovin.InitializeSdk ();
		AppLovin.SetUnityAdListener (this.gameObject.name);
		StartCoroutine (CallAds());
	}

	void OnLevelWasLoaded() {
		if (Application.loadedLevelName == "MainMenu") {
			int random = Random.Range(0, 10);
			if(random > 5) {
				ShowInterstitial();
			} else {
				ShowVideo();
			}
		}
	}

	IEnumerator CallAds() {
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds(3f));
		LoadInsterstitial ();
		LoadVideo ();
		AppLovin.ShowAd (AppLovin.AD_POSITION_TOP, AppLovin.AD_POSITION_CENTER);
	}

	void MakeSingleton() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(instance);
		}
	}

	public void LoadInsterstitial() {
		AppLovin.PreloadInterstitial ();
	}

	public void ShowInterstitial() {
		if (AppLovin.HasPreloadedInterstitial ()) {
			AppLovin.ShowInterstitial ();
		} else {
			LoadInsterstitial();
		}
	}

	public void LoadVideo() {
		AppLovin.LoadRewardedInterstitial ();
	}

	public void ShowVideo() {
		AppLovin.ShowRewardedInterstitial ();
	}

	void onAppLovinEventReceived(string ev){
		if(ev.Contains("DISPLAYEDINTER")){
			// An ad was shown.  Pause the game.
		}
		else if(ev.Contains("HIDDENINTER")){
			// Ad ad was closed.  Resume the game.
			// If you're using PreloadInterstitial/HasPreloadedInterstitial, make a preload call here.
			AppLovin.PreloadInterstitial();
		}
		else if(ev.Contains("LOADEDINTER")){
			// An interstitial ad was successfully loaded.
		}
		else if(string.Equals(ev, "LOADINTERFAILED")){
			// An interstitial ad failed to load.
			LoadInsterstitial();
		}  
		else if(ev.Contains("LOADEDREWARDED")){
			// A rewarded video was successfully loaded.
		}
		else if(ev.Contains("LOADREWARDEDFAILED")){
			// A rewarded video failed to load.
			LoadVideo();
		}
		else if(ev.Contains("HIDDENREWARDED")){
			// A rewarded video was closed.  Preload the next rewarded video.
			LoadVideo();
		}
	}

} // class


















































