using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text message, score;
    public Camera camero;

    // Start is called before the first frame update
    void Start()
    {
        ChangeScene.untimed = true;

        if (ChangeScene.endLvl)
        {
            camero.backgroundColor = new Color(1,0.86f,0);
            message.color = score.color = Color.black;
            message.text = "YOU WIN!";
        }

        score.text = "Final Score: " + PlayerScript.score.ToString("000000");
    }
}
