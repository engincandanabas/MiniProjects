using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public void PlayGame() {
		Application.LoadLevel ("Gameplay");
	}

	public void BackToMenu() {
		Application.LoadLevel ("MainMenu");
	}

}
