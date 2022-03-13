using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BaseTransition
{
    public BaseDecision Decision;
    public BaseState TrueState;
    public BaseState FalseState;
}
