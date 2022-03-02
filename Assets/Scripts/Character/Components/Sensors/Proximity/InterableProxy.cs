using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterableProxy : Sensor
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Interactable"){
            _SensorActivated = true;
        }
    }
    
    protected override void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Interactable"){
            _SensorActivated = false;
        }  
    }
}
