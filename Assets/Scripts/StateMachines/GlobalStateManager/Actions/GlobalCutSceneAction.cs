using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Global/CutScene", fileName = "CutScene")]
public class GlobalCutSceneAction : GlobalAction
{
    protected override void GlobalAct(GlobalStateManager controller)
    {
        if(!controller.CutSceneManager.CutSceneStarted && controller.RoomHasCutScene) controller.CutSceneManager.StartCutScene();
    }
}