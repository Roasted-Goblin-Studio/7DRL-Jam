using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Attacks/Detect Player In Explode Range", fileName = "DetectPlayerInMeleeRange")]
public class AIDetectPlayerInExplodeRange : AIDecision
{
    public override bool Decide(StateController controller)
    {   
        if(controller.ExplodeSensor.SensorActivated) return true;
        return false;
    }
}
