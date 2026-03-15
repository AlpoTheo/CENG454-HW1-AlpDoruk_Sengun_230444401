using UnityEngine;

public class FlightController : MonoBehaviour
{
    // speed values, adjustable from inspector
    [SerializeField] float pitchSpeed = 45f;
    [SerializeField] float yawSpeed = 45f;
    [SerializeField] float rollSpeed = 45f;
    [SerializeField] float thrustSpeed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // dont let physics mess with rotation
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    void HandleRotation()
    {
        // pitch - up/down arrows
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, pitch);

        // yaw - left/right arrows
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        // roll - Q and E keys
        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll = rollSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) roll = -rollSpeed * Time.deltaTime;

        transform.Rotate(Vector3.forward, roll);
    }

    void HandleThrust()
    {
        // space to move forward
        if (Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
    }
}
