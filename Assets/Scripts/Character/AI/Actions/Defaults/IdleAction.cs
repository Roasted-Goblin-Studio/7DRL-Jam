using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/General/Idle", fileName = "Idle")]

public class IdleAction : AIAction
{
    public override void Act(StateController controller)
    {
        controller.CharacterMovement.Horizontal = 0;
        controller.CharacterMovement.Vertical = 0;
    }
}
