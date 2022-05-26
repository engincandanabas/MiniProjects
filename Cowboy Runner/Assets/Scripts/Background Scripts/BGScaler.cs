using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {
	
	void Start () {
		var height = Camera.main.orthographicSize * 2f;
		var widht = height * Screen.width / Screen.height;

		if (gameObject.name == "Background") {
			transform.localScale = new Vector3 (widht, height, -2);
		} else {
			transform.localScale = new Vector3 (widht + 4f, 5, -2);
		}

	}

}
