using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    [Serializable]
    public class Snapshot {
        public GameObject snapshot;
        public int hour;
        public int minute;
    }

    public int startingSnapshotIndex;

    public Snapshot[] snapshots;

    public AnimationCurve hologramAppearAnimation;
    public float animationLength;

    public Material[] hologramMaterials;

    public TMP_Text clock;

    int curTime;


    CanvasGroup canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponentInParent<CanvasGroup>();
        canvas.alpha = 0;
        SwitchToSnapshot(startingSnapshotIndex);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.F)) {
            canvas.alpha = Mathf.Lerp(canvas.alpha, 1, 6 * Time.deltaTime);
        }
        else  {
            canvas.alpha = Mathf.Lerp(canvas.alpha, 0, 18 * Time.deltaTime);
        }
    }

    public void SwitchToSnapshot(int index) {
        StopAllCoroutines();
        StartCoroutine(SwitchSnaphot(index));
    }

    IEnumerator SwitchSnaphot(int index) {
        StartCoroutine(AnimateTime(snapshots[index]));
        yield return StartCoroutine(AnimateHologram(false));
        
        for(int i = 0; i < snapshots.Length; i++) {
            snapshots[i].snapshot.SetActive(i == index);
        }

        yield return StartCoroutine(AnimateHologram(true));
    }

    IEnumerator AnimateHologram(bool isAppearing) {
        float startTime = Time.time;

        float timeSinceStart = Time.time - startTime;

        while(timeSinceStart <= animationLength) {
            float curveValue = hologramAppearAnimation.Evaluate(timeSinceStart / animationLength) * 8 - 1;

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

    IEnumerator AnimateTime(Snapshot snapshot) {
        float startTime = Time.time;

        float timeSinceStart = Time.time - startTime;

        int targetTime = snapshot.hour * 60 + snapshot.minute;

        while(timeSinceStart <= animationLength * 2) {
            float curveValue = hologramAppearAnimation.Evaluate(timeSinceStart / (animationLength * 2));

            

            clock.text = TimeToString((int)Mathf.Lerp(curTime, targetTime, curveValue));
            
            
            yield return new WaitForEndOfFrame();
            timeSinceStart = Time.time - startTime;
        }
        curTime = targetTime;
    }

    public string TimeToString(int time) {
        return string.Format("{0}:{1:00}", time / 60, time % 60);
    }
}
