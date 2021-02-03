using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowME : MonoBehaviour
{
    public GameObject me;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(me.transform.position.x, transform.position.y, transform.position.z);
    }
}
