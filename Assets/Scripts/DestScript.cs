using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestScript : MonoBehaviour
{
    public bool hurts = true;
    public int hp = 1;
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
        if (hurts)
        {
            collision.gameObject.SendMessage("Hurt");
        }
    }
}
