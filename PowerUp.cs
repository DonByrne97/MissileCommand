using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    IEnumerator SpeedBoost(GameObject powerUpModel)
    {
        powerUpModel.GetComponent<Collider>().enabled = false;
        powerUpModel.GetComponent<Renderer>().enabled = false; 
        PlayerMovement.speed = PlayerMovement.speed * 2;
        yield return new WaitForSeconds(10);
        PlayerMovement.speed = 4.0f;
        Destroy(powerUpModel); 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(SpeedBoost(this.gameObject)); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
