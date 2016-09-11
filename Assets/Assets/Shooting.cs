using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject projectile;
    public GameObject music;
    public GameObject player;
    Character scriptPlayer;
    private float cooldown;
    public float fireDelay = .5F;
    public bool shooting = false;
    public float offsetY;

	// Use this for initialization
	void Start () {
		//player = this.gameObject;
        scriptPlayer = player.GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(scriptPlayer.shoot))
            shooting = true;
        if (Input.GetKeyUp(scriptPlayer.shoot))
            shooting = false;

        if(shooting & cooldown <= 0)
        {
            cooldown = fireDelay;
            GameObject bullet = Instantiate(projectile);
            bullet.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY);
            switch (player.tag)
            {
                case "Player 1":
                    bullet.tag = "Bullet 1";
                    break;
                case "Player 2":
                    bullet.tag = "Bullet 2";
                    break;
            }
            if (!scriptPlayer.facingRight)
                bullet.GetComponent<Projectile>().velocity = -(bullet.GetComponent<Projectile>().velocity);
            bullet.GetComponent<Projectile>().CorrectImage();
        }

	}
}
