using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScrollController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scroll(Vector2 move)
    {
        transform.position -= new Vector3(move.x, move.y);
    }
}
