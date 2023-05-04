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
    [SerializeField] float coyoteTimeCounter, coyoteTime;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded, secondJump;
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
        //if (!isGrounded) { direction = new Vector3(0f, 0f, vertical).normalized; }

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * direction;
            rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
        }
        else if(direction.magnitude == 0f)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f, ground);
        if (isGrounded) { 
            secondJump = true;
            coyoteTimeCounter = coyoteTime;
        }
        else { coyoteTimeCounter -= Time.deltaTime; }

        if (rb.velocity.y > 0f) { coyoteTimeCounter = 0f; }

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            coyoteTimeCounter = 0f;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        /*else if ( Input.GetButtonDown("Jump") && secondJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            secondJump = false;
        }*/
    }
}
