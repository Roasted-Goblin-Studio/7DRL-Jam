using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] protected BaseState _StartingState;
    [SerializeField] protected BaseState _RemainInState;
    protected BaseState _CurrentMacroState;

    protected void Awake()
    {
       _CurrentMacroState = _StartingState;
       HandleAwakeTasks();
    }

    protected void Start(){
        HandleStartTasks();
    }

    private void Update()
    {
        HandleLowPriorityTasks();
    }

    private void FixedUpdate(){
        HandleHighPriorityTasks();
    }

    protected virtual void HandleAwakeTasks(){

    }

    protected virtual void HandleStartTasks(){

    }

    protected virtual void HandleLowPriorityTasks(){
        if(CheckStateMachineIsActionable()) _CurrentMacroState.EvaluateState(this);
    }

    protected virtual void HandleHighPriorityTasks(){
        
    }

    protected virtual bool CheckStateMachineIsActionable(){
        if(_CurrentMacroState != null) return true;
        return false;
    }

    public virtual void TransitionToState(BaseState nextState = null)
    {   
        if (nextState != _RemainInState && nextState != null) _CurrentMacroState = nextState;
    }

    
}
