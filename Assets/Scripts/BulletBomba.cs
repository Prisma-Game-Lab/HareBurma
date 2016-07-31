using UnityEngine;
using System.Collections;

public class BulletBomba : MonoBehaviour {

	public float speed;

			// Use this for initialization
			void Start () {
			}


			// Update is called once per frame
			void Update (){
					Vector2 position = transform.position;
					position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
					transform.position = position;
					Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
					if (transform.position.x > max.x) {
							Destroy (gameObject);
					}
			}
	}
