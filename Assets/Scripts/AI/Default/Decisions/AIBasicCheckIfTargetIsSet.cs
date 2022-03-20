using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Default/Detect if Target is Set", fileName = "CheckTargetIsSet")]
public class AIBasicCheckIfTargetIsSet : AIBasicDecision
{
    protected override bool AIDecide(AIBasicStateController controller)
    {
        if(controller.Target == null) return false;
        return true;
    }
}
