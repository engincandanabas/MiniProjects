using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	[SerializeField]
	private MusicController musicController;

	[SerializeField]
	private GameObject settingsPanel;
	
	[SerializeField]
	private Animator settingsPanelAnim;

	[SerializeField]
	private Slider slider;

	public void OpenSettingsPanel() {
		slider.value = musicController.GetMusicVolume ();
		settingsPanel.SetActive (true);
		settingsPanelAnim.Play ("SlideIn");
	}
	
	public void CloseSettingsPanel() {
		StartCoroutine (CloseSettings ());
	}

	IEnumerator CloseSettings() {
		settingsPanelAnim.Play ("SlideOut");
		yield return new WaitForSeconds(1f);
		settingsPanel.SetActive (false);
	}

	public void GetVolume(float volume) {
		musicController.SetMusicVolume (volume);
	}

} // SettingsController














































