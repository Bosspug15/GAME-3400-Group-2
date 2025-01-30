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
    public string[] curText;
    int textIndex = 0;
    CanvasGroup group;

    bool isPaused = false;
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
        if(curText.Length == 0) {
            return;
        }

        
        if(!isShowingText) {
            percentageThroughText = 0;
            textIndex = 0;
            return;
        }
        else {
            percentageThroughText += textScrollSpeed * Time.deltaTime / curText[textIndex].Length;
            text.text = curText[textIndex].Substring(0, Math.Min(curText[textIndex].Length, (int)(curText[textIndex].Length * (percentageThroughText / 100.0))));
        }

        if(percentageThroughText >= 100 && !isPaused) {
            StartCoroutine(stopText());
        }
        
    }



    IEnumerator stopText() {
        isPaused = true;
        yield return new WaitForSeconds(textStayLength);
        isPaused = false;
        percentageThroughText = 0;
        textIndex++;
        if(curText.Length == textIndex) {
            isShowingText = false;
            group.alpha = 0;
            curText = new string[0];
        }
        StopCoroutine(stopText());
    }


    public void showText(string[] newText) {
        textIndex = 0;
        curText = newText;
        group.alpha = 1;
        isShowingText = true;
    }
}