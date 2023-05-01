using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform cam;
    public float speed;
    float walkSpeed, sprintSpeed;
    float horizontal, vertical;
    [SerializeField] float jumpForce = 1f;
    bool isGrounded;
    CapsuleCollider col;
    [SerializeField] LayerMask ground;

    void Start()
    {
        walkSpeed = speed;
        sprintSpeed = speed * 1.5f;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float radius = col.radius * 0.9f;
        Vector3 pos = transform.position + Vector3.up * (radius * 0.9f);
        isGrounded = Physics.CheckSphere(pos, radius, ground);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //walking
        if (direction.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * direction;
            rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
        }
    }
}
