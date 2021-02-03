using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool hurts = true;
    public float moveSpeed;
    public int hp = 1;
    public GameObject you;
    public Rigidbody rb;
    bool flip = false;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void DMG()
    {
        hp -= 1;

        if (hp == 0)
        {
            player.SendMessage("Points", 100);
            player.SendMessage("Killed");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.GetContact(0).otherCollider.CompareTag("Player"))
        {
            if (flip)
            {
                flip = false;
            }
            else flip = true;
        } else if (hurts)
        {
            collision.gameObject.SendMessage("Hurt");
        }
    }

    private void Update()
    {
        if (flip)
        {
            you.transform.Translate(new Vector3((-moveSpeed * Time.deltaTime), 0));
        }
        else you.transform.Translate(new Vector3((moveSpeed * Time.deltaTime), 0));
    }
}
