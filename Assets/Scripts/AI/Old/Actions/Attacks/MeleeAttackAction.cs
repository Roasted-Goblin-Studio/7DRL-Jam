using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAction : AIAttackAction
{
    protected override void Attack(StateController controller){
        controller.CharacterMeleeAttack.Attack();
    }
}
