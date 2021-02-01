using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string GoTo;
    static public bool endLvl = false, untimed = false;
    float timer = 2;

    public void GameOver()
    {
        SceneManager.LoadScene(GoTo);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            endLvl = true;
            print("nice one!");
        }
    }

    private void Update()
    {
        if (endLvl && !untimed)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                GameOver();
            }
        }
    }
}
