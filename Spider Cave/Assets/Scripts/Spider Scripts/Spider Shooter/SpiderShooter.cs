using UnityEngine;
using System.Collections;

public class SpiderShooter : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;
	
	void Start () {
		StartCoroutine (Attack());
	}

	IEnumerator Attack() {
		yield return new WaitForSeconds (Random.Range(2, 7));
		Instantiate (bullet, transform.position, Quaternion.identity);
		StartCoroutine (Attack());
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Player") {
			Destroy(target.gameObject);
		}
	}

}
