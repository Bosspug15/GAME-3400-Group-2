using UnityEngine;

public class VoiceClipPlay : MonoBehaviour
{
    AudioSource source;
    Collider collider;
    private bool AlreadyPlayer = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (AlreadyPlayer == false)
        {
            source.Play();
            AlreadyPlayer = true;
        }
    }
}
