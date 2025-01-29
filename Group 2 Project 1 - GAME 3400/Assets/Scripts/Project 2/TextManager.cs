using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    TextMeshProUGUI text;
    public float textScrollSpeed;
    public float textStayLength;
    bool isShowingText = false;
    float percentageThroughText = 0;
    public string curText;
    CanvasGroup group;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) {
            instance = this;
            group = GetComponentInParent<CanvasGroup>();
            text = GetComponent<TextMeshProUGUI>();
            group.alpha = 0;
        } else {
            Destroy(this.gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(curText == "") {
            return;
        }

        
        if(!isShowingText) {
            percentageThroughText = 0;
            return;
        }
        else {
            percentageThroughText += textScrollSpeed * Time.deltaTime;
            text.text = curText.Substring(0,Math.Min(curText.Length, (int)(curText.Length * (percentageThroughText / 100.0))));
        }

        if(percentageThroughText > 100) {
            StartCoroutine(stopText());
        }
        
    }

    IEnumerator stopText() {
        yield return new WaitForSeconds(textStayLength);
        isShowingText = false;
        group.alpha = 0;
        curText = "";
        StopCoroutine(stopText());
    }


    public void showText(string newText) {
        curText = newText;
        group.alpha = 1;
        isShowingText = true;
    }
}