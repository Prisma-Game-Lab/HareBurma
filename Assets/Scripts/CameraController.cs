using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

public Rigidbody2D playerRigidbody;
public Rigidbody2D cameraRigidbody;

    // Use this for initialization
    void Start () {

	}



	// Update is called once per frame
	void Update () {
    	cameraRigidbody.velocity = playerRigidbody.velocity;
	}
}
