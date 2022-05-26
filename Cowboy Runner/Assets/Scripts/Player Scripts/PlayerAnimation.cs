using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animator anim;
	
	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Obstacle") {
			anim.Play("Idle");
		}
	}

	void OnCollisionExit2D(Collision2D target) {
		if (target.gameObject.tag == "Obstacle") {
			anim.Play("Run");
		}
	}

}
