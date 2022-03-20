using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectPlayerInExplodeRange : AIDecision
{
    public override bool Decide(StateController controller)
    {   
        if(controller.ExplodeSensor.SensorActivated) return true;
        return false;
    }
}
