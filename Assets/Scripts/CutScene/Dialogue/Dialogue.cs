using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Dialogue
{
    [SerializeField] [TextArea(15,20)] private string _Dialogue;
    [SerializeField] private string _Speaker;
    [SerializeField] private float _DurationofText = 3;
    [SerializeField] private String _Target;
    [SerializeField] private Vector3 _TargetStartingOffset;
    [SerializeField] private bool _DestroyTargetOnFinish = false;
    [SerializeField] private bool _TargetFacingRight = false;
    private GameObject _TargetGameObject;

    public string DialogueText { get => _Dialogue; set => _Dialogue = value; }
    public string Speaker { get => _Speaker; set => _Speaker = value; }
    public float DurationofText { get => _DurationofText; set => _DurationofText = value; }
    public String Target { get => _Target; set => _Target = value; }
    public Vector3 TargetStartingOffset { get => _TargetStartingOffset; set => _TargetStartingOffset = value; }
    public GameObject TargetGameObject { get => _TargetGameObject; set => _TargetGameObject = value; }
    public bool DestroyTargetOnFinish { get => _DestroyTargetOnFinish; set => _DestroyTargetOnFinish = value; }
    public bool TargetFacingRight { get => _TargetFacingRight; set => _TargetFacingRight = value; }
}
