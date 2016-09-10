using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public KeyCode up, down, left, right, shoot;
	private KeyCode mostRecentDirection = KeyCode.None;
	public bool goingLeft, goingRight, goingUp, goingDown;
	public int health;
	public int maxHealth = 100;
	public bool facingRight;
	// velocity per frame
	public float velocity = 1F;
	private Animator animator;
	private int firstSpriteState;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.enabled = false;
		firstSpriteState = animator.GetCurrentAnimatorStateInfo (0).fullPathHash;
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPos = this.transform.position;
		if (Input.GetKeyDown (left)) {
			mostRecentDirection = left;
			setSpriteDir (false);
			facingRight = false;
			goingLeft = true;
		} else if (Input.GetKeyUp (left)) {
			goingLeft = false;
		} else if (Input.GetKeyDown (right)) {
			mostRecentDirection = right;
			setSpriteDir (true);
			facingRight = true;
			goingRight = true;
		} else if (Input.GetKeyUp (right)) {
			goingRight = false;
		}

		if (mostRecentDirection == left && goingLeft) {
			animator.enabled = true;
			float diff = velocity * Time.deltaTime;
			newPos.x -= diff;
		} else if (mostRecentDirection == right && goingRight) {
			animator.enabled = true;
			float diff = velocity * Time.deltaTime;
			newPos.x += diff;
		} else {
			animator.SetTime (0);
			animator.enabled = false;
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
