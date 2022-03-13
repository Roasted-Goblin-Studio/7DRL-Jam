using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Global/GlobalCheckCutSceneIsDone", fileName = "CheckCutSceneIsDone")]
public class GlobalCheckCutSceneIsDone : GlobalDecision
{
    protected override bool GlobalDecide(GlobalStateManager controller)
    {
        if(!controller.RoomHasCutScene) return true;
        if(controller.CutSceneManager == null) return false;
        if(controller.CutSceneManager.CutSceneFinished) return true;
        return false;
    }
}
