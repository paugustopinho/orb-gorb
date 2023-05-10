using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LavaPlatform : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startpos;
    public bool swaying;
    [SerializeField] float speed;

    private void Start()
    {
        speed = Random.Range(0.5f, 1.25f);
        startpos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = new Vector3(0f, -.05f, 0f);
            swaying = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = new Vector3(0f, .1f, 0f);
        }
    }

    private void Update()
    {
        if (transform.position.y >= startpos.y) { rb.velocity = Vector3.zero; swaying = true; }
        if (swaying)
        {
            float y = Mathf.PingPong(Time.time * speed, .5f);
            transform.position = new Vector3(transform.position.x, startpos.y - y, transform.position.z);
        }
    }
}
