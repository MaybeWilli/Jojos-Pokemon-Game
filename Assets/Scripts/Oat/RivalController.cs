using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalController : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public GameObject oat;
    private bool shouldMove = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(oat.transform.position.x, oat.transform.position.y)) < stopDistance)
            {
                shouldMove = false;
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
}
