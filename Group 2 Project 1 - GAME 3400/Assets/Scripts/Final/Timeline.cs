using System.Collections;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public int startingSnapshotIndex;

    public GameObject[] snapshots;

    public AnimationCurve hologramAppearAnimation;
    public float animationLength;

    public Material[] hologramMaterials;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchToSnapshot(startingSnapshotIndex);
    }

    public void SwitchToSnapshot(int index) {
        StopAllCoroutines();
        StartCoroutine(SwitchSnaphot(index));
    }

    IEnumerator SwitchSnaphot(int index) {
        yield return StartCoroutine(AnimateHologram(false));
        
        for(int i = 0; i < snapshots.Length; i++) {
            snapshots[i].SetActive(i == index);
        }

        yield return StartCoroutine(AnimateHologram(true));
    }

    IEnumerator AnimateHologram(bool isAppearing) {
        float startTime = Time.time;

        float timeSinceStart = Time.time - startTime;

        while(timeSinceStart <= animationLength) {
            float curveValue = hologramAppearAnimation.Evaluate(timeSinceStart / animationLength) * 10 - 1;

            if(!isAppearing) {
                curveValue = 5 - curveValue;
            }

            foreach(Material mat in hologramMaterials) {
                mat.SetFloat("_Height_Cutoff", curveValue);
            }
                
            
            yield return new WaitForEndOfFrame();
            timeSinceStart = Time.time - startTime;
        }
    }
}
