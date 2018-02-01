using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 5.0f;
    [SerializeField]
    private float maxRotationSpeed = 5.0f;

    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 newForce = new Vector3(0.0f, moveVertical);
        Vector3 newRotation = new Vector3(0.0f, 0.0f, moveHorizontal);

        rb.AddRelativeForce(newForce, ForceMode.Force);

        rb.AddTorque(newRotation, ForceMode.Force);

        // Cap the max forwards thrust.
        if (rb.velocity.y >= maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed);

        // Cap the max rotational thrust.
        if (rb.velocity.x >= maxRotationSpeed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxRotationSpeed);
    }
}
