using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 4.0f;
    private bool canMoveLeft;
    private bool canMoveRight; 

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left Bound")
        {
            canMoveLeft = false;
        }
        if(other.gameObject.tag == "Right Bound")
        {
            canMoveRight = false; 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Left Bound")
        {
            canMoveLeft = true; 
        }
        if(other.gameObject.tag == "Right Bound")
        {
            canMoveRight = true; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canMoveRight = true;
        canMoveLeft = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if(canMoveLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(canMoveRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
