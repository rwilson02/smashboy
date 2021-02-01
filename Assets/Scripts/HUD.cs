using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject player;
    public Text timer;
    public Text score;
    public Image hp1, hp2, hp3;
    int intScore;
    Color color;

    void HealthDeterminer(int hp)
    {
        switch (hp)
        {
            case 3:
                color = Color.green;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 1:
                color = Color.red;
                break;
            default:
                color = Color.black;
                break;
        }

        hp1.color = hp2.color = hp3.color = color;

        if (hp < 3)
        {
            hp3.color = new Color(hp3.color.r, hp3.color.g, hp3.color.b, 0.5f);
        }
        if (hp < 2)
        {
            hp2.color = new Color(hp2.color.r, hp2.color.g, hp2.color.b, 0.5f);
        }
        if (hp < 1)
        {
            hp1.color = new Color(hp1.color.r, hp1.color.g, hp1.color.b, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = player.GetComponent<PlayerScript>().dispTime.ToString();
        intScore = Mathf.Min(999999, PlayerScript.score);
        score.text = intScore.ToString("000000");
        HealthDeterminer(player.GetComponent<PlayerScript>().hp);
    }
}
