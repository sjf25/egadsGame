using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public KeyCode up, down, left, right, shoot;
	public bool goingLeft, goingRight, goingUp, goingDown;
	public int health;
	public bool facingRight;
	// velocity per frame
	public float velocity = 1F;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPos = this.transform.position;
		if (Input.GetKeyDown (left)) {
			goingLeft = true;
		} else if (Input.GetKeyUp (left)) {
			goingRight = false;
		}

		if (goingLeft) {
			float diff = velocity * Time.deltaTime;
			Debug.Log (diff);
			newPos.x -= diff;
			//newPos.x -= .1F;
		}
		this.transform.position = newPos;
	}

	public bool isDead() {
		return health <= 0;
	}
}
