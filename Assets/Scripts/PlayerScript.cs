using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, jumpForce, timer;
    public int hp = 3, lives = 2, dispTime;
    public GameObject you, checkpt;
    public Rigidbody rb;
    public Collider legs;
    public Vector3 respawnPoint;
    string moveAxis = "Horizontal";
    int jumpTimes = 2; //haha nice double jump
    public bool timed = true;

    
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

    void Die() {
        you.SetActive(false);
        lives--;
        timed = false;
        checkpt.SendMessage("Dead");
    }

    void Back()
    {
        you.transform.position = respawnPoint;
        rb.velocity = Vector3.zero;
        hp = 3;
        timed = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (hp == 0 || this.gameObject.transform.position.y < -20 || timer < 0) {
            Die();
        };

        if (timed)
        {
            timer -= Time.deltaTime;
            dispTime = Mathf.CeilToInt(timer);
        }
    }
}
