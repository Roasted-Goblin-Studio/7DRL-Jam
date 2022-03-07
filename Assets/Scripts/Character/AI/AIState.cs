using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class AIState : ScriptableObject
{
    public AIAction[] AIActions;
    public AITransition[] AITransitions;

    public void EvaluateState(StateController controller)
    {
        if (controller == null)
        {
            Debug.Log("AI StateController is null..");
            return;
        }
        PerformActions(controller);
        EvaluateTransitions(controller);
    }

    public void EvaluateTransitions(StateController controller)
    {
        if (AITransitions != null || AITransitions.Length > 1)
        {
            for (int i = 0; i < AITransitions.Length; i++) 
            {
                bool decisionResult = AITransitions[i].Decision.Decide(controller);
                if (decisionResult)
                {
                    controller.TransitionToState(AITransitions[i].TrueState);
                }
                else
                {
                    controller.TransitionToState(AITransitions[i].FalseState);
                }
            }
        }
    }

    public void PerformActions(StateController controller)
    {
        if (AIActions != null)
        {
            foreach (AIAction action in AIActions)
            {
                action.Act(controller);
            }
        }
    }
}
