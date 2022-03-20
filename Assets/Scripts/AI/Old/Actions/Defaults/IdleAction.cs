using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void Act(StateController controller)
    {
        controller.CharacterMovement.Horizontal = 0;
        controller.CharacterMovement.Vertical = 0;
    }
}
