using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float countdown = 4F;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject fight;

    public float timer = 120F;
    public float cactusScore;
    public float humanScore;
    public bool start = false;

	// Use this for initialization
	void Awake () {
        one.GetComponent<SpriteRenderer>().enabled = true;
        two.GetComponent<SpriteRenderer>().enabled = false;
        three.GetComponent<SpriteRenderer>().enabled = false;
        fight.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            if (countdown < 1)
            {
                one.GetComponent<SpriteRenderer>().enabled = false;
                two.GetComponent<SpriteRenderer>().enabled = false;
                three.GetComponent<SpriteRenderer>().enabled = false;
                fight.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (countdown < 2)
            {
                one.GetComponent<SpriteRenderer>().enabled = true;
                two.GetComponent<SpriteRenderer>().enabled = false;
                three.GetComponent<SpriteRenderer>().enabled = false;
                fight.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (countdown < 3)
            {
                one.GetComponent<SpriteRenderer>().enabled = false;
                two.GetComponent<SpriteRenderer>().enabled = true;
                three.GetComponent<SpriteRenderer>().enabled = false;
                fight.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else if (!start)
            start = true;

        if(start)
            timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(cactusScore > humanScore)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("cactusWin");
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("humanWin");
            }
        }
	}
}
