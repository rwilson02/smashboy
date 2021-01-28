using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, jumpForce;
    public GameObject you;
    public Rigidbody rb;
    public Collider legs;
    string moveAxis = "Horizontal";
    int jumpTimes = 2; //haha nice double jump
    
    void OnCollisionEnter(Collision col)
    {
        //checks to see if your feet hit the ground
        if(col.GetContact(0).thisCollider == legs && col.GetContact(0).otherCollider.CompareTag("ground"))
        {
            jumpTimes = 2;
        }
    }

    void Move()
    {
        int dash;
        float axis = Input.GetAxis(moveAxis);
        
        if (Input.GetButton("Fire3"))
        {
            dash = 2; //you run twice as fast as you walk
        }
        else dash = 1;

        you.transform.Translate(new Vector3(axis * speed * Time.deltaTime * dash, 0));

        if (Input.GetButtonDown("Jump") && jumpTimes > 0) //if you can jump
        {
            if(rb.velocity.y < 0)
            {
                //if you're falling, you stop to jump in the air again
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse); 
            jumpTimes -= 1;
            Debug.Log(jumpTimes);
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
