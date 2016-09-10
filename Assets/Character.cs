using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public KeyCode up, down, left, right, shoot;
	public bool goingLeft, goingRight, goingUp, goingDown;
	public int health;
	public bool facingRight;
	// velocity per frame
	public float velocity = 1F;
	// time for the character to switch sprite images
	public int spriteCycleTime = 500;
	private int spriteCycleCounter = 0;

	private SpriteRenderer spriteRend;
	private Sprite[] walkingSprites = new Sprite[3];

	// Use this for initialization
	void Start () {
		spriteRend = GetComponent<SpriteRenderer> ();
		for(int i = 0; i < walkingSprites.Length; i++) {
			//walkingSprites[i] = 
		}
	}

	// Update is called once per frame
	void Update () {
		//spriteCycleCounter += Time.deltaTime;
		if (spriteCycleCounter >= spriteCycleTime) {
			//this.
		}

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
