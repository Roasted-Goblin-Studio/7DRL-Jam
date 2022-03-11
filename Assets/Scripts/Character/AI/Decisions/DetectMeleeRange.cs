using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/General/Detect Player In Melee Range", fileName = "DetectPlayerInMeleeRange")]
public class DetectMeleeRange : AIDecision
{
    [SerializeField] private float _MinAttackRange;

    public override bool Decide(StateController controller)
    {
        // Debug.Log("Controller: [" + controller.Target.transform.position + "] | [ " + controller.transform.position + "]");
        float HorizontalDistance = controller.transform.position.x - controller.Target.transform.position.x;
        float VerticalDistance = controller.transform.position.y - controller.Target.transform.position.y;
        // Debug.Log("[ " + HorizontalDistance + " ] | [ " + VerticalDistance + " ]");
        Debug.Log("I'm deciding");
        if(HorizontalDistance < _MinAttackRange || VerticalDistance < _MinAttackRange) return true;
        return false;
    }
}
