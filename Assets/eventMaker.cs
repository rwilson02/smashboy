using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventMaker : MonoBehaviour
{
    public void happen()
    {
        SendMessageUpwards("PainTrain");
    }
}
