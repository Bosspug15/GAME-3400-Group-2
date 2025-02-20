using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    public AudioSource footstepSound;

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }

    }
}
