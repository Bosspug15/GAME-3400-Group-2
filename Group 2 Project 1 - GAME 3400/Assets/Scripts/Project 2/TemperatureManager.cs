using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public static TemperatureManager Instance;

    public int maxHeat;
    public float heatLossRate;

    public float curHeat;

    public bool isNearHeatSource = false;


    void Start()
    {
        if(Instance == null) {
            Instance = this;

            curHeat = maxHeat;
        } else {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Stops us from losing heat if we're next to a heat source
        if(!isNearHeatSource) {
            curHeat -= heatLossRate * Time.deltaTime;
            print("loosing");
        }        

        curHeat = Mathf.Clamp(curHeat, 0, maxHeat);
    }
}
