using UnityEngine;

public class AlwaysLookAtPlayer : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the inspector

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player);
    }
}
