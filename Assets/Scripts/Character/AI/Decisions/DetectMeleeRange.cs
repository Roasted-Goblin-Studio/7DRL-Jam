using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Attack/Detect Player In Melee Range", fileName = "DetectPlayerInMeleeRange")]
public class DetectMeleeRange : AIDecision
{
    [SerializeField] [Range(0,5)] private float _MinAttackRange;

    public override bool Decide(StateController controller)
    {   
        if(controller.MeleeSensor.SensorActivated) return true;
        return false;
    }
}
