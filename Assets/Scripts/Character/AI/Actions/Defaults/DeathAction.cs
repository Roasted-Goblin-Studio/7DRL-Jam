using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/General/Death", fileName = "Death")]
public class DeathAction : AIAction
{
    public override void Act(StateController controller)
    {
        controller.CharacterMovement.StopAllMovement();
        controller.TransitionToState(controller.RemainInState);
                                /*
                            //\\
                            //  \\
                            //    \\          -------------------
                            // DeAd \\     /                      \
                        // ------ \\   |                       |
                        || ( .) ( .)||  |                       |
                        <||      >   ||> |                       |
                        ||      _   ||  |__                     |__
                        \\ ________//      |                       |_
                                | |          |                         \
                                | |__________|                        _ \____
                                |____________________________________/ |_____\   
                                */
    }
}
