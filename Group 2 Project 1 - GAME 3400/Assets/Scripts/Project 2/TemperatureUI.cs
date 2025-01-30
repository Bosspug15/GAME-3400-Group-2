using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class TemperatureUI : MonoBehaviour
{
    Vignette coldEffect;
    
    private void Start() {
        //Gross but gets the vignette effect
        GetComponent<Volume>().profile.TryGet<Vignette>(out coldEffect);
        coldEffect.intensity.overrideState = true;
    }

    // Update is called once per frame
    void Update()
    {
        print(1f - (TemperatureManager.Instance.curHeat / (float)TemperatureManager.Instance.maxHeat));
        coldEffect.intensity.value = 1f - (TemperatureManager.Instance.curHeat / (float)TemperatureManager.Instance.maxHeat);
    }
}
