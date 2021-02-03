using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, jumpForce, timer, painx;
    public int hp = 3, lives = 3, dispTime;
    public static int score = 0;
    public GameObject you, checkpt, pain;
    public Rigidbody rb;
    public Collider legs, body;
    public Vector3 respawnPoint;
    public AudioSource jump, hurt, superjump, die, music;
    public Animator anim;
    string moveAxis = "Horizontal";
    int jumpTimes = 2; //haha nice double jump
    public bool timed = true;

    public KeyCode debug, swing;

    private void Start()
    {
        painx = pain.transform.localPosition.x;
    }

    void OnCollisionEnter(Collision col)
    {
        //checks to see if your feet hit the ground
        if(col.GetContact(0).thisCollider == legs && col.GetContact(0).otherCollider.CompareTag("ground"))
        {
            jumpTimes = 2;
            anim.SetInteger("jumped", jumpTimes);
        }
    }

    void Move()
    {
        int dash;
        float axis = Input.GetAxis(moveAxis);

        if (axis < 0)
        {
            pain.transform.localPosition = new Vector3(-painx, pain.transform.localPosition.y);
            anim.GetComponentInParent<SpriteRenderer>().flipX = true;
        }
        else {
            pain.transform.localPosition = new Vector3(painx, pain.transform.localPosition.y);
            anim.GetComponentInParent<SpriteRenderer>().flipX = false; 
        }

        

        anim.SetFloat("speed", Mathf.Abs(axis));
        
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
            
            if (rb.velocity.y > 4)
            {
                superjump.Play();
            } else jump.Play();

            jumpTimes -= 1;
            anim.SetInteger("jumped", jumpTimes);
            Debug.Log(jumpTimes);
        }

    
    }

    void Hurt()
    {
        hurt.Play();
        hp -= 1;
        StartCoroutine(Invuln());
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

    void Points(int amt)
    {
        score += amt;
    }

    void Killed()
    {
        die.Play();
    }

    IEnumerator Invuln()
    {
        body.enabled = false;
        yield return new WaitForSeconds(1.25f);
        body.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(this.gameObject.transform.position.y < -20)
        {
            hp = 0;
        }

        if (hp == 0 || timer < 0) {
            Die();
        };

        if (timed)
        {
            timer -= Time.deltaTime;
            dispTime = Mathf.CeilToInt(timer);
        }

        if (Input.GetKeyDown(swing) && !anim.GetBool("swung"))
        {
            anim.SetBool("swung", true);
        }

        if (Input.GetKeyDown(debug))
        {
            print(painx);
        }
    }
}
