using UnityEngine;

public class RadioVoiceLine : MonoBehaviour
{
    AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.enabled = MonsterAnimator.Instance.numOfPapersPickedUp >= 1;
    }
}
