using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    public Transform orientation;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");

        dir = dir.normalized * speed;

        rb.linearVelocity = new Vector3(dir.x, rb.linearVelocity.y, dir.z);
    }
}
