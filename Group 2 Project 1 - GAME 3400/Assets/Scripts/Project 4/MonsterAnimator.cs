using UnityEngine;

public class MonsterAnimator : MonoBehaviour
{
    public static MonsterAnimator Instance;
    
    public float numOfPapersPickedUp;

    public float numRequiredForScare;
    public Animator monsterAnimator;

    public float lookStrictness;
    public float lookTimeToClose;
    float lookTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfPapersPickedUp >= numRequiredForScare) {
            monsterAnimator.SetBool("OpenDoor", true);

            if(Vector3.Dot(Camera.main.transform.forward, transform.position) < -lookStrictness) {
                lookTime += Time.deltaTime;
            }

            if(lookTime >= lookTimeToClose) {
                monsterAnimator.SetBool("CloseDoor", true);
            }
        }
    }
}
