using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Attack/Melee", fileName = "MeleeAttack")]
public class MeleeAttackAction : AIAttackAction
{
    protected override void Attack(StateController controller){
        controller.CharacterMeleeAttack.Attack();
    }
}
