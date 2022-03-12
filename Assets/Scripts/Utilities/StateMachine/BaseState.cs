using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State/Base", fileName = "State")]
public class BaseState : ScriptableObject
{
    public BaseAction[] AIActions;
    public BaseTransition[] BaseTransitions;

    public void EvaluateState(BaseStateController controller)
    {
        if (controller == null) return;
        PerformActions(controller);
        EvaluateTransitions(controller);
    }

    public void EvaluateTransitions(BaseStateController controller)
    {
        if (BaseTransitions != null || BaseTransitions.Length > 1)
        {
            for (int i = 0; i < BaseTransitions.Length; i++) 
            {
                bool decisionResult = BaseTransitions[i].Decision.Decide(controller);
                if (decisionResult)
                {
                    controller.TransitionToState(BaseTransitions[i].TrueState);
                }
                else
                {
                    controller.TransitionToState(BaseTransitions[i].FalseState);
                }
            }
        } 
        controller.TransitionToState();
    }


    public void PerformActions(BaseStateController controller)
    {
        if (AIActions == null) return;
        foreach (BaseAction action in AIActions)
        {
            action.Act(controller);
        }
    }
}
