using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour {

    public GameObject player;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //if(player.GetComponent("Character").isDead())
        {
            player.transform.position = this.transform.position;
        }
	}
}
