using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicDecision : BaseDecision
{
    public override bool Decide(BaseStateController controller)
    {
        return AIDecide((AIBasicStateController) controller);
    }

    protected virtual bool AIDecide(AIBasicStateController controller){
        return false;
    }
}
