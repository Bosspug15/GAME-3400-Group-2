using UnityEngine;

public class Timeline : MonoBehaviour
{
    public int startingSnapshotIndex;

    public GameObject[] snapshots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchToSnapshot(startingSnapshotIndex);
    }

    public void SwitchToSnapshot(int index) {
        for(int i = 0; i < snapshots.Length; i++) {
            snapshots[i].SetActive(i == index);
        }
    }
}
