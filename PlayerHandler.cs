using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHandler : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText; 
    public GameObject bullet;
    public GameObject youLoseText; 
    public Transform bulletSpawnPoint; 
    public static int ammo;
    public static int hp;
    public Text ammoText;
    public Text healthText;
    public Text timer; 
    private float timeUntilNextLevel = 15; 

    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
        hp = 5; 
    }

    void Fire()
    {
        ammo--;
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = timeUntilNextLevel.ToString();
        scoreText.text = score.ToString(); 
        if(timeUntilNextLevel > 0)
        {
            timeUntilNextLevel -= Time.deltaTime; 
        }
        if(timeUntilNextLevel <= 0)
        {
            Enemy.speed = Enemy.speed + 0.5f;
            timeUntilNextLevel = 15; 
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(ammo != 0)
            {
                Fire(); 
            }
            if(ammo == 0)
            {
                Debug.Log("You're out of ammo!");
                Spawning.maxSpawnTime = 0.5f;
                Enemy.speed = 5.0f;
            }
        }
        ammoText.text = ammo.ToString();
        healthText.text = hp.ToString(); 
    }
}
