using UnityEngine;

public class CleanupScript : MonoBehaviour
{
    public AudioClip cleanSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Destorying Mess");
            PlayCleanNoise();
            Destroy(gameObject);
        }
    }

    private void PlayCleanNoise()
    {
        AudioSource.PlayClipAtPoint(cleanSFX, transform.position);
    }
}
