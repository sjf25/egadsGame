using UnityEngine;
using System.Collections;

public class GuitarScript : MonoBehaviour {

    public int pointsPerSec = 100;
    public GameObject gameManager;
    public GameObject playerHolding;

    private GameObject guitar;
    private GameManager managerScript;
    private Sprite guitarSprite;

	// Use this for initialization
	void Start () {
        guitar = this.gameObject;
        managerScript = gameManager.GetComponent<GameManager>();
        guitarSprite = guitar.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerHolding != null)
        {
            guitar.transform.position = new Vector3(playerHolding.transform.position.x, playerHolding.transform.position.y);
            switch(playerHolding.tag){
                case "Player 1":
                    managerScript.cactusScore += pointsPerSec * Time.deltaTime;
                    break;
                case "Player 2":
                    managerScript.humanScore += pointsPerSec * Time.deltaTime;
                    break;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject temp = coll.gameObject;
        if(playerHolding == null & (temp.tag == "Player 1" | temp.tag == "Player 2"))
        {
            playerHolding = temp;
            guitar.GetComponent<Animator>().enabled = false;
            guitar.GetComponent<SpriteRenderer>().sprite = guitarSprite;
        }
    }

    public void DropGuitar()
    {
        playerHolding = null;
        guitar.GetComponent<Animator>().enabled = true;
    }
}
