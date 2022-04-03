using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Death", fileName = "Death")]
public class AIBasicDeathAction : AIBasicAction
{
    private float _LengthOfDeathState = 0;
    private float _TimeUntilDeathStateEnds = 0;

    public float LengthOfDeathState { get => _LengthOfDeathState; set => _LengthOfDeathState = value; }
    public float TimeUntilDeathStateEnds { get => _TimeUntilDeathStateEnds; set => _TimeUntilDeathStateEnds = value; }

    protected override void AIAct(AIBasicStateController controller)
    {
        controller.CharacterMovement.StopAllMovement();
        if (_TimeUntilDeathStateEnds == 0) {
            _TimeUntilDeathStateEnds = Time.time + _LengthOfDeathState;
        }
        
        if (Time.time >= _TimeUntilDeathStateEnds) controller.TransitionToState(controller.RemainInState);
    }
}


                             /*
                            //\\
                           //  \\
                          //    \\           --------------------
                         // DeAd \\        /                      \
                        // ------ \\       |                       |
                        || ( .) ( .)||     |                       |
                        <||      >   ||>   |                       |
                        ||      _   ||     |_                      |_
                        \\ ________//      |_                       |_
                                | |          |                         \
                                | |__________|                        _ \____
                                |____________________________________/ |_____\   
                                */
