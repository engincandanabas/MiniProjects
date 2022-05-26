using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;
	
	private AudioSource bgMusicClip;
	
	private float musicVolume;

	void Awake() {
		GetAudioSource ();
	}

	void Start () {
		musicVolume = puzzleGameSaver.musicVolume;
		PlayOrTurnOfMusic (musicVolume);
	}

	void GetAudioSource() {
		bgMusicClip = GetComponent<AudioSource> ();
	}

	public void SetMusicVolume(float volume) {
		PlayOrTurnOfMusic (volume);
	}

	void PlayOrTurnOfMusic(float volume) {
		musicVolume = volume;
		bgMusicClip.volume = musicVolume;

		if (bgMusicClip.volume > 0) {
			if (!bgMusicClip.isPlaying) {
				bgMusicClip.Play ();
			}

			puzzleGameSaver.musicVolume = musicVolume;
			puzzleGameSaver.SaveGameData ();

		} else if (bgMusicClip.volume == 0) {
			if(bgMusicClip.isPlaying) {
				bgMusicClip.Stop();
			}

			puzzleGameSaver.musicVolume = musicVolume;
			puzzleGameSaver.SaveGameData ();

		}

	}

	public float GetMusicVolume() {
		return this.musicVolume;
	}


} // MusicController


















































