using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Attack/Kamikaze", fileName = "KamikazeAttack")]
public class AIExplodeAttackAction : AIAttackAction
{
    [SerializeField] private float _KamikazeDamage = 2;

    protected override void Attack(StateController controller){
         
        if(controller.ExplodeRangeSensor.SensorActivated){
            CharacterHealth targetsHealth = controller.Target.GetComponentInParent<CharacterHealth>();
            targetsHealth.Damage(_KamikazeDamage);
        }

        controller.CharacterHealth.Die();
    }
}
