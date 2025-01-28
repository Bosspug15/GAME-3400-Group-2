using UnityEngine;

public class PlayerMovementWithTemp : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    TemperatureManager playerTemp;

    private float newSpeed;

    public Transform orientation;

    Rigidbody rb;

    private float speedDebuff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        speedDebuff = playerTemp.curHeat;
        if (speedDebuff <= speed)
        {
             newSpeed = speed / 2;
        }
        else
        {
            newSpeed = speed - (speed / speedDebuff);
        }

        Debug.Log("Speed value: " + newSpeed);

        if (speedDebuff != 0)
        {
            Vector3 dir = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");

            dir = dir.normalized * newSpeed;

            rb.linearVelocity = new Vector3(dir.x, rb.linearVelocity.y, dir.z);
        }
        else
        {
            //player froze and died, reset the level after playing freeze animation (if we do that)
        }
    }
}
