using UnityEngine;

public class ShowRead : MonoBehaviour
{
    public bool opened;
    public GameObject paperUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opened = false;
    }

    public void openCloseLetter(bool open)
    {
        opened = open;

        if (opened == false)
        {
            paperUI.SetActive(true);
            opened = true;
            return;
        }

        if (opened == true)
        {
            paperUI.SetActive(false);
            opened = false;
            return;
        }
    }

    }
