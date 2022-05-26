using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform player;

	public float minX, maxX;
	
	void Start () {
		player = GameObject.Find ("Player").transform;
	}

	void Update () {
		if (player != null) {
			Vector3 temp = transform.position;
			temp.x = player.position.x;

			if(temp.x < minX)
				temp.x = minX;

			if(temp.x > maxX)
				temp.x = maxX;

			temp.y = player.position.y + 3.2f;

			transform.position = temp;
		}
	}


} //CameraFollow
















































