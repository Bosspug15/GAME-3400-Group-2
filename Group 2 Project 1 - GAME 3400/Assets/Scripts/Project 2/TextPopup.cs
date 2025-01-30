using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    public string[] text;
    bool hasTriggered = false;


    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }


    private void OnTriggerEnter(Collider other) {
        if(!hasTriggered) {
            hasTriggered = true;
            TextManager.instance.showText(text);
        }
    }

    private void OnApplicationQuit() {
        GetComponent<MeshRenderer>().enabled = true;
    }

}