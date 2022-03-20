using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Global State Manager/Decisions/GameStarted", fileName = "GameStarted")]
public class GlobalRoomStarted : GlobalDecision
{
    protected override bool GlobalDecide(GlobalStateManager controller)
    {
        return true;
    }
}
