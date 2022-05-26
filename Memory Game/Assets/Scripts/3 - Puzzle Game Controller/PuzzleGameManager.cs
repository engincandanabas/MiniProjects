using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;

	[SerializeField]
	private GameFinished gameFinished;

	private List<Button> puzzleButtons = new List<Button>();
	
	private List<Animator> puzzleButtonsAnimators = new List<Animator>();
	[SerializeField]
	private List<Sprite> gamePuzzleSprites = new List<Sprite>();
	
	private int level;
	private string selectedPuzzle;

	private Sprite puzzleBackgroundImage;

	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex;
	private string firstGuessPuzzle, secondGuessPuzzle;

	private int countTryGuess;

	private int countCorrectGuess;
	private int gameGuess;

	public void PickAPuzzle() {

		if (!firstGuess) {
			firstGuess = true;

			firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			firstGuessPuzzle = gamePuzzleSprites[firstGuessIndex].name;

			StartCoroutine(TurnPuzzleButtonUp(puzzleButtonsAnimators[firstGuessIndex], 
			                                  puzzleButtons[firstGuessIndex], gamePuzzleSprites[firstGuessIndex]));

		} else if (!secondGuess) {
			secondGuess = true;

			secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			secondGuessPuzzle = gamePuzzleSprites[secondGuessIndex].name;
			
			StartCoroutine(TurnPuzzleButtonUp(puzzleButtonsAnimators[secondGuessIndex], 
			                                  puzzleButtons[secondGuessIndex], gamePuzzleSprites[secondGuessIndex]));

			StartCoroutine(CheckIfThePuzzlesMatch(puzzleBackgroundImage));

			countTryGuess++;

		}

	}

	IEnumerator CheckIfThePuzzlesMatch(Sprite puzzleBackgroundImage) {
	
		yield return new WaitForSeconds (1.7f);

		if (firstGuessPuzzle == secondGuessPuzzle) {
		
			puzzleButtonsAnimators [firstGuessIndex].Play ("FadeOut");
			puzzleButtonsAnimators [secondGuessIndex].Play ("FadeOut");

			CheckIfTheGameIsFinished();

		} else {

			StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimators[firstGuessIndex], 
			                                    puzzleButtons[firstGuessIndex], puzzleBackgroundImage));

			StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimators[secondGuessIndex], 
			                                    puzzleButtons[secondGuessIndex], puzzleBackgroundImage));
		
		}

		yield return new WaitForSeconds (.7f);

		firstGuess = secondGuess = false;
		
	}

	void CheckIfTheGameIsFinished() {
		countCorrectGuess++;

		if (countCorrectGuess == gameGuess) {
//			Debug.Log("Game Ends No More Puzzles");
			CheckHowManyGuesses();
		}

	}

	void CheckHowManyGuesses() {
		int howManyGuesses = 0;

		switch(level) {
			
		case 0:
			howManyGuesses = 5;
			break;
			
		case 1:
			howManyGuesses = 10;
			break;
			
		case 2:
			howManyGuesses = 15;
			break;
			
		case 3:
			howManyGuesses = 20;
			break;
			
		case 4:
			howManyGuesses = 25;
			break;
			
		}

		if (countTryGuess < howManyGuesses) {
			gameFinished.ShowGameFinishedPanel (3);

			puzzleGameSaver.Save(level, selectedPuzzle, 3);

		} else if (countTryGuess < (howManyGuesses + 5)) {
			gameFinished.ShowGameFinishedPanel (2);

			puzzleGameSaver.Save(level, selectedPuzzle, 2);

		} else {
			gameFinished.ShowGameFinishedPanel (1);
			puzzleGameSaver.Save(level, selectedPuzzle, 1);
		}

	}

	public List<Animator> ResetGameplay() {
		firstGuess = secondGuess = false;

		countTryGuess = 0;
		countCorrectGuess = 0;

		gameFinished.HideGameFinishedPanel ();

		return puzzleButtonsAnimators;
	}

	IEnumerator TurnPuzzleButtonUp(Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("TurnUp");
		yield return new WaitForSeconds (.4f);
		btn.image.sprite = puzzleImage;
	}

	IEnumerator TurnPuzzleButtonBack(Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("TurnBack");
		yield return new WaitForSeconds (.4f);
		btn.image.sprite = puzzleImage;
	}

	void AddListeners() {
		foreach (Button btn in puzzleButtons) {
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(() => PickAPuzzle());
		}
	}
	
	public void SetUpButtonsAndAnimators(List<Button> buttons, List<Animator> animators) {
		this.puzzleButtons = buttons;
		this.puzzleButtonsAnimators = animators;

		gameGuess = puzzleButtons.Count / 2;

		puzzleBackgroundImage = puzzleButtons [0].image.sprite;

		AddListeners ();

	} 
	
	public void SetGamePuzzleSprites(List<Sprite> gamePuzzleSprites) {
		this.gamePuzzleSprites = gamePuzzleSprites;
	} 
	
	public void SetLevel(int level) {
		this.level = level;
	}
	
	public void SetSelectedPuzzle(string selectedPuzzle) {
		this.selectedPuzzle = selectedPuzzle;
	}
		
} // PuzzleGameManager


















































