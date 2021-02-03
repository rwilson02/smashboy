using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILL : MonoBehaviour
{
    bool hurt = false;
    KeyCode yes;

    private void Start()
    {
        yes = GetComponentInParent<PlayerScript>().swing;
    }

    IEnumerator Pain()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        hurt = true;
        yield return new WaitForSecondsRealtime(0.1f);
        hurt = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (hurt && other.CompareTag("enemy"))
        {
            other.SendMessage("DMG");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(yes))
        {
            StartCoroutine(Pain());
        }
    }
}
