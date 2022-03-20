using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Default/Idle", fileName = "Idle")]
public class AIBasicIdleAction : AIBasicAction
{
    protected override void AIAct(AIBasicStateController controller){
        Debug.Log("Just chilling");
        controller.CharacterMovement.StopAllMovement();
    }
}
