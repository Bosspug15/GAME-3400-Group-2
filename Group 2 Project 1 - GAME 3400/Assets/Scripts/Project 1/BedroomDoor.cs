using System.Collections;
using UnityEngine;

public class BedroomDoor : MonoBehaviour
{
    public float waitTime;

    Animator animator;
    public AnimationClip doorOpening;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(waitTime);
        animator.Play(doorOpening.name);
        StopAllCoroutines();
    }
}
