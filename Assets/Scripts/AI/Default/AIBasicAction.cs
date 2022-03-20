using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicAction : BaseAction
{
    public override void Act(BaseStateController controller)
    {
        AIAct((AIBasicStateController) controller);
    }

    protected virtual void AIAct(AIBasicStateController controller){
        
    }


}
