using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 comebackPoint;
    float recTime, timer = 3;
    bool touched = false, dead = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        comebackPoint = this.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!touched)
        {
            //this is where you come back to, we get the time you touched it
            other.GetComponent<PlayerScript>().checkpt = this.gameObject;
            other.GetComponent<PlayerScript>().respawnPoint = comebackPoint;
            recTime = other.GetComponent<PlayerScript>().timer;

            //rough rounding up to the nearest multiple of 10 
            recTime /= 10;
            recTime = Mathf.Ceil(recTime);
            recTime *= 10;

            touched = true;
        }
    }

    public void Dead()
    {
        dead = true;
        print("please hold");
    }

    private void Update()
    {
        if (dead)
        {
            print(timer);
            timer -= Time.deltaTime;
        }

        if(timer < 0)
        {
            dead = false;
            print("rise from your grave");
            player.SetActive(true);
            player.SendMessage("Back");
            timer = 3;
            player.GetComponent<PlayerScript>().timer = recTime;
        }
    }
}
