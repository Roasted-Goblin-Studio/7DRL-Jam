using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Attack/Detect Player in Range Attack Range", fileName = "DetectPlayerInRangeAttackRange")]
public class DetectRangedAttackRange : AIDecision
{
    [SerializeField] [Range(0,25)] private float _MinAttackRange;

    public override bool Decide(StateController controller)
    {   
        float HorizontalDistance = System.Math.Abs(controller.transform.position.x - controller.Target.transform.position.x);
        float VerticalDistance = System.Math.Abs(controller.transform.position.y - controller.Target.transform.position.y);
        if(HorizontalDistance < _MinAttackRange || VerticalDistance < _MinAttackRange) return true;
        return false;
    }
}
