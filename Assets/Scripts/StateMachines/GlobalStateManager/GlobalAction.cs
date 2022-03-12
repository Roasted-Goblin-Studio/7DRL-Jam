using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GlobalAction : BaseAction
{
    public override void Act(BaseStateController controller)
    {
        GlobalAct((GlobalStateManager) controller);
    }

    protected abstract void GlobalAct(GlobalStateManager controller);
}
