using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AirTimer : MonoBehaviour {

	private Slider slider;

	private GameObject player;

	public float air = 10f;

	private float airBurn = 1f;

	void Awake () {
		GetReferences ();
	}

	void Update () {
		if (!player)
			return;

		if (air > 0) {
			air -= airBurn * Time.deltaTime;
			slider.value = air;
		} else {
			GetComponent<GameplayController>().PlayerDied();
			Destroy(player);
		}


	}

	void GetReferences() {
		player = GameObject.Find ("Player");
		slider = GameObject.Find ("Air Slider").GetComponent<Slider> ();

		slider.minValue = 0f;
		slider.maxValue = air;
		slider.value = slider.maxValue;

	}


} // AirTimer

















































