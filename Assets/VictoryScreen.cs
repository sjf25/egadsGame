using UnityEngine;
using System.Collections;

public class VictoryScreen : MonoBehaviour {

    public float countdown = 6F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("arena");
        }
	}
}
