using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Cut Scene/Start", fileName = "Start")]
public class CutSceneStartDialogueAction : BaseAction
{
    public override void Act(BaseStateController controller)
    {
        CutSceneAct((CutSceneManager) controller);
    //    if(_CutSceneStarted){
    //        Debug.Log("Cut Scene Started.");
    //        _CutSceneStarted = true;
    //    }
    }

    private void CutSceneAct(CutSceneManager controller){
        if(controller.CutSceneStarted){
           Debug.Log("Cut Scene Started.");
           controller.CutSceneStarted = true;
       }
    }
}
