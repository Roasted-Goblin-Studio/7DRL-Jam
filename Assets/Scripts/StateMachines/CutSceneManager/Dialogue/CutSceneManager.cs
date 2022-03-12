using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : BaseStateController
{
    [SerializeField] private bool _CutSceneStarted = false;
    public bool CutSceneStarted { get=>_CutSceneStarted; set => _CutSceneStarted = value; }
    private bool _CutSceneFinished = false;
    public bool CutSceneFinished { get=>_CutSceneFinished; set => _CutSceneFinished = value; }

    // Could Upgrade to be a list of locations.. 
    [SerializeField] private Transform _CutSceneStartingLocation;
    public Transform CutSceneStartingLocation { get=> _CutSceneStartingLocation; set => _CutSceneStartingLocation = value; }

    public void StartCutScene(){
        _CutSceneStarted = true;
    }
}