using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/General/Death", fileName = "Death")]
public class DeathAction : AIAction
{
    private float _LengthOfDeathState = 0;
    private float _TimeUntilDeathStateEnds = 0;

    public float LengthOfDeathState { get => _LengthOfDeathState; set => _LengthOfDeathState = value; }
    public float TimeUntilDeathStateEnds { get => _TimeUntilDeathStateEnds; set => _TimeUntilDeathStateEnds = value; }

    public override void Act(StateController controller)
    {
        if (_TimeUntilDeathStateEnds == 0) {
            controller.CharacterMovement.StopAllMovement();
            _TimeUntilDeathStateEnds = Time.time + _LengthOfDeathState;
        }
        
        if (Time.time >= _TimeUntilDeathStateEnds) controller.TransitionToState(controller.RemainInState);
    }
}

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
