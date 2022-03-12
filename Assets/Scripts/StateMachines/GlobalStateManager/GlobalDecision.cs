using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class GlobalDecision : BaseDecision
{
    public override bool Decide(BaseStateController controller)
    {
        return GlobalDecide((GlobalStateManager) controller);
    }

    protected abstract bool GlobalDecide(GlobalStateManager controller);
}
