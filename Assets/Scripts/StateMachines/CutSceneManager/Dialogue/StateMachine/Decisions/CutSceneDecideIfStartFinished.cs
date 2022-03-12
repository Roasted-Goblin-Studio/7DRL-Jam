using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Cut Scene/Check that CutScene Started", fileName = "CheckIfStarted")]
public class CutSceneDecideIfStartFinished : BaseDecision
{
    public override bool Decide(BaseStateController controller)
    {
        return CutSceneController((CutSceneManager) controller);
    }

    private bool CutSceneController(CutSceneManager controller){
        if(controller.CutSceneStarted) return true;
        return false;
    }
}
