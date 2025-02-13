using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float ZoomFOV;
    float baseFOV;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) {
            Camera.main.fieldOfView = ZoomFOV;
        } else {
            Camera.main.fieldOfView = baseFOV;
        }
    }
}
