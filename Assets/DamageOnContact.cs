using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour {

    public int damage;
    public bool touching;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        touching = true;
        GameObject obj = coll.gameObject;
        if(obj.tag == "Player 1" | obj.tag == "Player 2")
            coll.gameObject.GetComponent<Character>().health -= damage; 
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        touching = false;
    }
}
