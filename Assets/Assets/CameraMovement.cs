using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private GameObject person1, person2;
	private int padding = 5;
	// Use this for initialization
	void Start () {
		person1 = GameObject.FindWithTag ("Person 1");
		person2 = GameObject.FindWithTag ("Person 2");
	}
	
	// Update is called once per frame
	void Update () {
		Camera mainCam = Camera.main;
		GameObject camGame = Camera.main.gameObject;
		Vector3 p1Pos = person1.transform.position;
		Vector3 p2Pos = person2.transform.position;
		if (Mathf.Abs (p1Pos.x - p2Pos.x) > Mathf.Abs (p1Pos.y - p2Pos.y)) {
			mainCam.orthographicSize = (Mathf.Abs (p1Pos.x - p2Pos.x) + padding) / (2 * mainCam.aspect);
			//camGame.
		}
	}
}
