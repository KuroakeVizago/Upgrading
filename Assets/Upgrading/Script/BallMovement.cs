using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [Header("Coin Colect : ")]
    [SerializeField] public int coinCollected;
    [SerializeField] Text coinText;

    [Header("Config : ")]
    [SerializeField] float speed = 45f;
    [SerializeField] float jumpForce = 350f;
    [SerializeField] Rigidbody rigidbody;

    bool isGrounded = true;

    void Start()
    {
        if (!rigidbody)
            rigidbody = GetComponent<Rigidbody>();

        coinText.text = "Coin Colected: 0";
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
            if (Input.GetKey(KeyCode.Space))
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
		{
            coinCollected += 1;
            coinText.text = "Coin Colected: " + coinCollected.ToString();

            Destroy(other.transform.parent.gameObject);
		}
	}
}
