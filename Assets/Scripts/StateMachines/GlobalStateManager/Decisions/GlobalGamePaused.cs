using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Global State Manager/Decisions/GamePaused", fileName = "GamePaused")]
public class GlobalGamePaused : GlobalDecision
{
    protected override bool GlobalDecide(GlobalStateManager controller)
    {
        if(controller.GameIsPaused) return true;
        return false;
    }
}
