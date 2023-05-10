using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Vector3 startpos;
    Rigidbody rb;
    bool isAtEnd;

    private void Start()
    {
        startpos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = collision.gameObject.GetComponent<PlayerMovement>().startpos;
            transform.position = startpos;
        }
    }

    private void Update()
    {
        if (transform.position.z >= 110f)
        {
            isAtEnd = true;
            transform.position = startpos;
        }
        if (!isAtEnd)
        {
            rb.velocity = new Vector3(0f, 0f, 11f);
        }
    }
}
