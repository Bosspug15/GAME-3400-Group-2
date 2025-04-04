using UnityEngine;

public class PerspectiveShift : MonoBehaviour
{
    public GameObject targetObject;

    // How far the camera has to look away from the object for it to shift
    [Range(0, 1)]
    public float lookStrictness = 0.1f;
    public GameObject[] objectsToAppear;

    public GameObject blockerCollider;

    bool canShift = false;

    Camera playerCamera;
    void Start()
    {
        playerCamera = Camera.main;

        blockerCollider.SetActive(false);

        targetObject.SetActive(true);
        foreach (GameObject obj in objectsToAppear) {
            obj.SetActive(false);
        }
    }


    void Update()
    {
        if(!canShift) {
            return;
        }

        Vector3 objectDirection = (targetObject.transform.position - playerCamera.transform.position).normalized;

        //TLDR if we're looking enough away from the object
        if(Vector3.Dot(playerCamera.transform.forward, objectDirection) < -lookStrictness) {

            targetObject.SetActive(false);

            foreach (GameObject obj in objectsToAppear) {
                obj.SetActive(true);
            }

            //Since we don't need to shift a second time we can just destroy the trigger
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter(Collider other) {
        canShift = true;
        blockerCollider.SetActive(true);
    }
}
