using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : BaseStateController
{
    [SerializeField] private bool _CutSceneStarted = false;
    public bool CutSceneStarted { get=>_CutSceneStarted; set => _CutSceneStarted = value; }

}
