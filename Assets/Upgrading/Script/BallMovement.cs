using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    [Header("Config : ")]
    [SerializeField] float speed = 45f;
    [SerializeField] float jumpForce = 350f;
    [SerializeField] Rigidbody rigidbody;

    bool isGrounded = true;

    void Start()
    {
        if (!rigidbody)
            rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Movement();

        Jump();

    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                rigidbody.velocity = rigidbody.velocity + (Vector3.up * jumpForce);
                //rigidbody.AddForce(new Vector3(0, jumpForce * Time.deltaTime, 0), ForceMode.Impulse);
            }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

}
