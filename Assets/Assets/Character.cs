using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public KeyCode up = KeyCode.UpArrow, down = KeyCode.DownArrow,
		left = KeyCode.DownArrow, right = KeyCode.RightArrow, shoot = KeyCode.Space;
	private KeyCode mostRecentDirection = KeyCode.None;
	public bool goingLeft, goingRight, goingUp, goingDown;
	public int health;
	public int maxHealth = 10;
	public float jumpHeight = 5F;
	public bool facingRight;
	// velocity per frame
	public float jumpForce = 10F;
	public float velocity = 1F;
	private Animator animator;
	private Sprite returnSprite;
	private bool jumping = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.enabled = false;
		returnSprite = GetComponent<SpriteRenderer> ().sprite;
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

		if (Input.GetKeyDown (up) && !jumping) {
			jumping = true;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
		}

		if (mostRecentDirection == left && goingLeft) {
			animator.enabled = !jumping;
			if(jumping)
				GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("cacti2.jump");
			float diff = velocity * Time.deltaTime;
			newPos.x -= diff;
		} else if (mostRecentDirection == right && goingRight) {
			animator.enabled = !jumping;
			if(jumping)
				GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("cacti2.jump");
			float diff = velocity * Time.deltaTime;
			newPos.x += diff;
		} else {
			animator.enabled = false;
			if(jumping)
				GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("cacti2.jump");
			else
				GetComponent<SpriteRenderer> ().sprite = returnSprite;
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
	public void OnCollisionEnter2D(Collision2D collide) {
		jumping = false;
		Debug.Log (collide.gameObject.name);
	}
}
