using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed, jumpForce;
    public GameObject you;
    public Rigidbody rb;
    public Collider legs;
    public KeyCode jump, run;
    public string moveAxis = "Horizontal";
    private int jumpTimes = 2;
    
    void OnCollisionEnter()
    {
        jumpTimes = 2;
    }

    void Move()
    {
        int dash;
        float axis = Input.GetAxis(moveAxis);
        
        if (Input.GetKey(run))
        {
            dash = 2;
        }
        else dash = 1;

        you.transform.Translate(new Vector3(axis * speed * Time.deltaTime * dash, 0));

        if (Input.GetKeyDown(jump) && jumpTimes > 0)
        {
            if(rb.velocity.y < 0)
            {
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
