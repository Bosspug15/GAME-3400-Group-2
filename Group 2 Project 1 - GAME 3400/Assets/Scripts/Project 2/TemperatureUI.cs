using UnityEngine.UI;
using UnityEngine;

public class TemperatureUI : MonoBehaviour
{
    Image bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = TemperatureManager.Instance.curHeat / TemperatureManager.Instance.maxHeat;
    }
}
