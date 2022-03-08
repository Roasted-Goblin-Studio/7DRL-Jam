using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AITransition
{
    public AIDecision Decision;
    public AIState TrueState;
    public AIState FalseState;
}
