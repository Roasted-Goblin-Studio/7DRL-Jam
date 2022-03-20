using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
