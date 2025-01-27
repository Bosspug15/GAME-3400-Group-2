using UnityEngine;

public class HeatSource : MonoBehaviour
{
    public float warmingRate;
    public float heatRadius;

    //How the warming rate falls off with distance to the source
    public AnimationCurve heatFalloff;


    SphereCollider trigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            TemperatureManager.Instance.isNearHeatSource = true;
            float distanceFromSource = Vector3.Distance(other.transform.position, transform.position);



            TemperatureManager.Instance.curHeat += heatFalloff.Evaluate(distanceFromSource / heatRadius) * Time.deltaTime;
            print("Heating!: " + TemperatureManager.Instance.curHeat);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            TemperatureManager.Instance.isNearHeatSource = false;
        }
    }

    #if UNITY_EDITOR
    private void OnValidate() {
        if(trigger == null) {
            trigger = GetComponent<SphereCollider>();
        }

        trigger.radius = heatRadius;
    }
    #endif
}
