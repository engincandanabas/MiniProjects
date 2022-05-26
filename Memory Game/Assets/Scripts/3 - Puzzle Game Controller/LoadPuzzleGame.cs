using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadPuzzleGame : MonoBehaviour {

	[SerializeField]
	private PuzzleGameManager puzzleGameManager;

	[SerializeField]
	private LevelLocker levelLocker;

	[SerializeField]
	private LayoutPuzzleButtons layoutPuzzleButtons;

	[SerializeField]
	private GameObject puzzleLevelSelectPanel;

	[SerializeField]
	private Animator puzzleLevelSelectAnim;

	[SerializeField]
	private GameObject puzzleGamePanel1, puzzleGamePanel2, puzzleGamePanel3, puzzleGamePanel4, puzzleGamePanel5;
	
	[SerializeField]
	private Animator puzzleGamePanelAnim1, puzzleGamePanelAnim2, puzzleGamePanelAnim3, puzzleGamePanelAnim4, puzzleGamePanelAnim5;

	private int puzzleLevel;
	
	private string selectedPuzzle;	

	private List<Animator> anims;

	public void LoadPuzzle(int level, string puzzle) {
		this.puzzleLevel = level;
		this.selectedPuzzle = puzzle;

		layoutPuzzleButtons.LayoutButtons (level, selectedPuzzle);

		switch (puzzleLevel) {

		case 0:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel1, puzzleGamePanelAnim1));
			break;

		case 1:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel2, puzzleGamePanelAnim2));
			break;

		case 2:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel3, puzzleGamePanelAnim3));
			break;

		case 3:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel4, puzzleGamePanelAnim4));
			break;

		case 4:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel5, puzzleGamePanelAnim5));
			break;

		}

	}

	public void BackToPuzzleLevelSelectMenu() {

		anims = puzzleGameManager.ResetGameplay ();

		levelLocker.CheckWhichLevelsAreUnlocked (selectedPuzzle);

		switch (puzzleLevel) {
		case 0:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel1, puzzleGamePanelAnim1));
			break;
			
		case 1:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel2, puzzleGamePanelAnim2));
			break;
			
		case 2:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel3, puzzleGamePanelAnim3));
			break;
			
		case 3:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel4, puzzleGamePanelAnim4));
			break;
			
		case 4:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel5, puzzleGamePanelAnim5));
			break;
		}

	}

	IEnumerator LoadPuzzleLevelSelectMenu(GameObject puzzleGamePanel, Animator puzzleGamePanelAnim) {
		puzzleLevelSelectPanel.SetActive (true);
		puzzleLevelSelectAnim.Play ("SlideIn");
		puzzleGamePanelAnim.Play ("SlideOut");

		yield return new WaitForSeconds (1f);

		foreach (Animator anim in anims) {
			anim.Play("Idle");
		}

		yield return new WaitForSeconds (.5f);

		puzzleGamePanel.SetActive (false);
	}
	
	IEnumerator LoadPuzzleGamePanel(GameObject puzzleGamePanel, Animator puzzleGamePanelAnim) {
		puzzleGamePanel.SetActive (true);
		puzzleGamePanelAnim.Play ("SlideIn");
		puzzleLevelSelectAnim.Play ("SlideOut");
		yield return new WaitForSeconds (1f);
		puzzleLevelSelectPanel.SetActive (false);
	}


} // LoadPuzzleGame









































