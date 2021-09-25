using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 15.0f; 
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Garbage")
        {
            Destroy(this.gameObject); 
        }
        if(other.gameObject.tag == "Enemy")
        {
            PlayerHandler.score++; 
            PlayerHandler.ammo++; 
            Destroy(other.gameObject);
            Destroy(this.gameObject); 
        }
    }
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime; 
    }
}
