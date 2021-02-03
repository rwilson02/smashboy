using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public GameObject gerund;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprt = GetComponent<SpriteRenderer>();
        sprt.drawMode = SpriteDrawMode.Tiled;
        sprt.size = new Vector2(gerund.transform.localScale.x, gerund.transform.localScale.y);
    }
}
