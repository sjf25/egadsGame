using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private GameObject person1, person2;
	private float padding = 10F;
	// Use this for initialization
	void Start () {
		person1 = GameObject.FindWithTag ("Player 1");
		person2 = GameObject.FindWithTag ("Player 2");
	}
	
	// Update is called once per frame
	void Update () {
		Camera mainCam = Camera.main;
		GameObject camGame = Camera.main.gameObject;
		Vector3 p1Pos = person1.transform.position;
		Vector3 p2Pos = person2.transform.position;
		if (Mathf.Abs (p1Pos.x - p2Pos.x) > Mathf.Abs (p1Pos.y - p2Pos.y)) {
			mainCam.orthographicSize = (Mathf.Abs (p1Pos.x - p2Pos.x) + padding) / (2F * mainCam.aspect);
		} else {
			mainCam.orthographicSize = (Mathf.Abs (p1Pos.y - p2Pos.y) + padding) / 2F;
		}
		Vector3 newCamVec = camGame.transform.position;
		newCamVec.x = (p1Pos.x + p2Pos.x) / 2F;
		newCamVec.y = (p1Pos.y + p2Pos.y) / 2F;
		camGame.transform.position = newCamVec;
		//camGame.transform.position.x = (p1Pos.x + p2Pos.x) / 2.0;
		//camGame.transform.position.y = (p1Pos.y + p2Pos.y) / 2.0;
	}
}
