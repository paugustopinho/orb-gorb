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
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask ground;

    void Start()
    {
        sprintSpeed = speed;
        walkSpeed = speed / 1.5f;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Inputs();
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        transform.rotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * direction;
            rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
        }
    }

    void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.25f, ground);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
