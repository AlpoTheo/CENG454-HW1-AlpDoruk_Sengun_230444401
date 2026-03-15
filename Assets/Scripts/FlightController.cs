// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Alp Doruk Sengun | Student ID: 230444401

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;   // degrees/second
    [SerializeField] private float yawSpeed   = 45f;   // degrees/second
    [SerializeField] private float rollSpeed  = 45f;   // degrees/second
    [SerializeField] private float thrustSpeed = 5f;   // units/second

    // Task 3-A: Rigidbody reference for physics interaction
    private Rigidbody rb;

    void Start()
    {
        // Task 3-B: Cache the Rigidbody component and freeze its rotation
        // so the physics engine does not interfere with our manual rotation.
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Task 3-C: Read input axes and apply rotation each frame

        // Pitch: Arrow Up/Down rotate around the local right axis
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, pitch);

        // Yaw: Arrow Left/Right rotate around the local up axis
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        // Roll: Q key rolls left, E key rolls right around forward axis
        float roll = 0f;
        if (Input.GetKey(KeyCode.Q))
            roll = rollSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E))
            roll = -rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, roll);
    }

    private void HandleThrust()
    {
        // Task 3-D: Spacebar moves the aircraft forward along its local forward axis
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}
