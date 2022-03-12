using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Attack/Ranged", fileName = "RangedAttack")]
public class AIRangedAttackAction : AIAttackAction
{
    protected override void Attack(StateController controller){
        controller.CharacterAttack.AIInitiateWeapon(controller.Target);
    }
}
