using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Global/GamePaused", fileName = "GamePaused")]
public class GlobalGamePaused : GlobalDecision
{
    protected override bool GlobalDecide(GlobalStateManager controller)
    {
        if(controller.GameIsPaused) return true;
        return false;
    }
}
