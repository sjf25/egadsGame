using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour {

    public GameObject player;
    private Character script;

	// Use this for initialization
	void Start () {
        script = player.GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        if (script.isDead())
        {
            player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            script.health = script.maxHealth;
        }
	}
}
