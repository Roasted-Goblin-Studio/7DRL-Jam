using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/General/Detect Player In Range", fileName = "DetectPlayerInRange")]
public class DetectPlayerInRange : AIDecision
{
    // Check if the StateController.Target has been set, if it has return true

    public override bool Decide(StateController controller)
    {
        return CheckTarget(controller);
    }

    private bool CheckTarget(StateController controller)
    {
        if(controller.Target == null) return false;
        return true;
    }
}
