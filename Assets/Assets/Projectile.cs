using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float velocity = 1F;
    public int damage = 1;
    public int health = 1;
    public bool music = false;
    public int deleteDistance = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x + velocity * Time.deltaTime, this.transform.position.y);
        if(this.health <= 0 | Mathf.Abs(this.gameObject.transform.position.x) > deleteDistance)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            Destroy(this.gameObject);
        if (this.tag == "Bullet 1")
        {
            if (!music & coll.gameObject.tag == "Bullet 2")
                coll.gameObject.GetComponent<Projectile>().health -= damage;
            else if (coll.gameObject.tag == "Player 2")
            {
                coll.gameObject.GetComponent<Character>().health -= damage;
                health -= 1;
            }
        }
        else if (this.tag == "Bullet 2")
        {
            if (!music & coll.gameObject.tag == "Bullet 1")
                coll.gameObject.GetComponent<Projectile>().health -= damage;
            else if (coll.gameObject.tag == "Player 1")
            {
                coll.gameObject.GetComponent<Character>().health -= damage;
                health -= 1;
            }
        }
    }

    public void CorrectImage()
    {
		Vector3 scaling = this.transform.localScale;
		scaling.x *= Mathf.Sign (velocity);
		this.transform.localScale = scaling;
    }
}
