using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles;

	private List<GameObject> obstaclesForSpawing = new List<GameObject>();

	void Awake() {
		InitializeObstacles ();
	}

	void Start () {
		StartCoroutine (SpawnRandomObstacle ());
	}

	void InitializeObstacles() {
		int index = 0;
		for(int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate(obstacles[index], new Vector3(transform.position.x,
			                                                           transform.position.y, -2), Quaternion.identity) as GameObject;
			obstaclesForSpawing.Add(obj);
			obstaclesForSpawing[i].SetActive(false);
			index++;
			if(index == obstacles.Length) 
				index = 0;
		}
	}

	void Shuffle() {
		for(int i = 0; i < obstaclesForSpawing.Count; i++) {
			GameObject temp = obstaclesForSpawing[i];
			int random = Random.Range(i, obstaclesForSpawing.Count);
			obstaclesForSpawing[i] = obstaclesForSpawing[random];
			obstaclesForSpawing[random] = temp;
		}
	}

	IEnumerator SpawnRandomObstacle() {
		yield return new WaitForSeconds (Random.Range(1.5f, 4.5f));

		int index = Random.Range (0, obstaclesForSpawing.Count);
		while (true) {
			if(!obstaclesForSpawing[index].activeInHierarchy) {
				obstaclesForSpawing[index].SetActive(true);
				obstaclesForSpawing[index].transform.position = new Vector3(transform.position.x, transform.position.y, -2);
				break;
			} else {
				index = Random.Range (0, obstaclesForSpawing.Count);
			}
		}

		StartCoroutine (SpawnRandomObstacle ());

	}

} // ObstacleSpawner

























































