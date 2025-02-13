using UnityEngine;

public class CleanupScript : MonoBehaviour
{
    public AudioClip cleanSFX;
    
    public void Clean() {
        MonsterAnimator.Instance.numOfPapersPickedUp++;
            //Debug.Log("Destorying Mess");
            PlayCleanNoise();
            Destroy(gameObject);
    }

    private void PlayCleanNoise()
    {
        AudioSource.PlayClipAtPoint(cleanSFX, transform.position);
    }
}
