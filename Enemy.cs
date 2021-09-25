using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Enemy : MonoBehaviour
{
    public static float speed = 1.0f;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Base")
        {
            PlayerHandler.hp--;
            if(PlayerHandler.hp == 0)
            {
                Destroy(GameObject.Find("player"));
                Destroy(GameObject.Find("enemy_spawn_timer"));
                Destroy(GameObject.Find("timer_text"));
            }
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime; 
    }
}
