using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        img.enabled = false;
    }
    public void clicked()
    {
        if (img.enabled)
        {
            img.enabled = false;
        }
        else img.enabled = true;
    }
}
