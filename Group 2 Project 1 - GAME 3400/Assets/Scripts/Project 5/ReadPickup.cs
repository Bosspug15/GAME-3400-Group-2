using UnityEngine;

public class ReadPickup : MonoBehaviour
{
    private ShowRead currentReadObject = null;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentReadObject != null && currentReadObject.opened)
            {
                currentReadObject.openCloseLetter(true);
                currentReadObject = null;
                return; 
            }

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 4f))
            {
                ShowRead readObject = hit.collider.GetComponent<ShowRead>();

                if (readObject != null)
                {
                    currentReadObject = readObject;
                    readObject.openCloseLetter(false);
                }
            }
        }
    }
}
