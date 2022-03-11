using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] private string _TargetForSensor;
    protected Collider2D _Sensor;
    protected bool _SensorActivated = false;
    

    public bool SensorActivated {get => _SensorActivated; set => _SensorActivated = value;}

    // Start is called before the first frame update
    void Start()
    {
        _Sensor = GetComponent<Collider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log(other.tag);    
        if(other.tag == _TargetForSensor){
            _SensorActivated = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == _TargetForSensor){
            _SensorActivated = false;
        } 
    }
}
