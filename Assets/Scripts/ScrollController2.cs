using UnityEngine;
using System.Collections;

public class ScrollController2 : MonoBehaviour {

	public float speed = 0.5f;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 offset = new Vector2 (Time.time * speed, 0);

		Vector2 position = transform.position;
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		transform.position = position;
	        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
	        if (transform.position.x > max.x) {
			Destroy (gameObject);
			}

		rend.material.mainTextureOffset = offset;
	}
}
