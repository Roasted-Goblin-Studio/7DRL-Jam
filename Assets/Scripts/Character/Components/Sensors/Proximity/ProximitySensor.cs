using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySensor : Sensor
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Interactable"){
            _SensorActivated = true;
        }
        else if(other.tag == "InvisibleWall"){
            _SensorActivated = true;
        }
    }
    
    protected override void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Interactable"){
            _SensorActivated = false;
        }
        else if(other.tag == "InvisibleWall"){
            _SensorActivated = false;
        }
    }
}
