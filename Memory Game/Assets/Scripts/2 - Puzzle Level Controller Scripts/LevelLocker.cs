using UnityEngine;
using System.Collections;

public class LevelLocker : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;

	[SerializeField]
	private StarsLocker starsLocker;
	
	[SerializeField]
	private GameObject[] levelStarsHolders;
	
	[SerializeField]
	private GameObject[] levelsPadlocks;
	
	private bool[] candyPuzzleLevels;
	private bool[] transportPuzzleLevels;
	private bool[] fruitPuzzleLevels;

	void Awake() {
		DeactivatePadlocksAndStarHolders ();
	}
	
	void Start () {
		GetLevels ();
	}

	public void CheckWhichLevelsAreUnlocked(string selectedPuzzle) {

		DeactivatePadlocksAndStarHolders ();
		GetLevels ();

		switch (selectedPuzzle) {

		case "Candy Puzzle":

			for(int i = 0; i < candyPuzzleLevels.Length; i++) {
				if(candyPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLocker.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}

			break;

		case "Transport Puzzle":
			
			for(int i = 0; i < transportPuzzleLevels.Length; i++) {
				if(transportPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLocker.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}
			
			break;
			
		case "Fruit Puzzle":
			
			for(int i = 0; i < fruitPuzzleLevels.Length; i++) {
				if(fruitPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLocker.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}
			
			break;

		
		}

	}

	void DeactivatePadlocksAndStarHolders() {
		for(int i = 0; i < levelStarsHolders.Length; i++) {
			levelStarsHolders[i].SetActive(false);
			levelsPadlocks[i].SetActive(false);
		}
	}

	void GetLevels() {
		candyPuzzleLevels = puzzleGameSaver.candyPuzzleLevels;
		transportPuzzleLevels = puzzleGameSaver.transportPuzzleLevels;
		fruitPuzzleLevels = puzzleGameSaver.fruitPuzzleLevels;
	}

	public bool[] GetPuzzleLevels(string selectedPuzzle) {

		switch (selectedPuzzle) {

		case "Candy Puzzle":
			return this.candyPuzzleLevels;
			break;

		case "Transport Puzzle":
			return this.transportPuzzleLevels;
			break;

		case "Fruit Puzzle":
			return this.fruitPuzzleLevels;
			break;

		default:
			return null;
			break;

		}

	}

} // LevelLocker


















































