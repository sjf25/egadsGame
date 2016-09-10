using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
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
			setSpriteDir (false);
			facingRight = false;
			goingLeft = true;
		} else if (Input.GetKeyUp (left)) {
			goingLeft = false;
		} else if (Input.GetKeyDown (right)) {
			setSpriteDir (true);
			facingRight = true;
			goingRight = true;
		} else if (Input.GetKeyUp (right)) {
			goingRight = false;
		}

		if (goingLeft) {
			float diff = velocity * Time.deltaTime;
			newPos.x -= diff;
		} else if (goingRight) {
			float diff = velocity * Time.deltaTime;
			newPos.x += diff;
		}
		this.transform.position = newPos;
	}

	public bool isDead() {
		return health <= 0;
	}
	public bool isFacingRight() {
		return facingRight;
	}
	public void setSpriteDir(bool right) {
		Vector3 scaling = this.transform.localScale;
		if (right && scaling.x > 0)
			scaling.x *= -1;
		else if (!right && scaling.x < 0)
			scaling.x *= -1;
		this.transform.localScale = scaling;
	}
}
