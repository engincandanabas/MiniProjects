using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float speed = 0.1f;

	private Vector2 offset = Vector2.zero;
	private Material mat;
	
	void Start () {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
	}

	void Update () {
		offset.x += speed * Time.deltaTime;
		mat.SetTextureOffset ("_MainTex", offset);
	}
}
