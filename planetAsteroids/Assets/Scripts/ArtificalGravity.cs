using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificalGravity : MonoBehaviour {

    [SerializeField]
    private Transform planet;

    private Rigidbody rb;

    [SerializeField]
    private float gravity = 9.81f;

    [SerializeField]
    private float stopDistance = 10f;

    [SerializeField]
    private float maxRotationSpeed = 5.0f;

    private void Awake()
    {
        planet = GameObject.FindWithTag("Planet").GetComponent<Transform>();

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(rb.position, planet.position);

        if (dist > stopDistance)
        rb.position = Vector3.MoveTowards(rb.position, planet.position, gravity * Time.deltaTime);

    }


}
