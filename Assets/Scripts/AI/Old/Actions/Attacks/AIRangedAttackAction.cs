using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRangedAttackAction : AIAttackAction
{
    protected override void TellAction(StateController controller)
    {
        controller.CharacterAttack.AttackAnimation();
        Debug.Log("attack animator called");
        base.TellAction(controller);
    }

    protected override void Attack(StateController controller){
        base.Attack(controller);
        controller.CharacterAttack.AIInitiateWeapon(controller.Target);
    }
}
