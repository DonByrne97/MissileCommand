using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawning : MonoBehaviour
{
    public GameObject speedPowerup;
    public Transform powerupSpawnPosition; 

    public Text enemySpawnText;
    public GameObject youLoseText; 
    public GameObject enemy; 
    public GameObject[] possibleSpawnPoints;
    public static float spawnTimer;
    public static float maxSpawnTime; 
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 5.0f;
        maxSpawnTime = 5.0f; 
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(5);
        int chance = Random.Range(0, 4); 
        if(chance == 2)
        {
            if(GameObject.Find("speed_powerup").activeSelf == true)
            {
                Debug.Log("Did not spawn a powerup."); 
            }
            else
            {
                Instantiate(speedPowerup, powerupSpawnPosition.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHandler.hp == 0)
        {
            youLoseText.SetActive(true); 
        }
        enemySpawnText.text = spawnTimer.ToString(); 
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime; 
        }
        if(spawnTimer <= 0)
        {
            int position = Random.Range(0, (possibleSpawnPoints.Length + 1));
            Instantiate(enemy, possibleSpawnPoints[position].transform.position, Quaternion.identity);
            spawnTimer = maxSpawnTime;
        }
    }
}
