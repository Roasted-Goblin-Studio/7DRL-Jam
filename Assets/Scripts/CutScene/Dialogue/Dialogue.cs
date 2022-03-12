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

    public string DialogueText { get => _Dialogue; set => _Dialogue = value; }
    public string Speaker { get => _Speaker; set => _Speaker = value; }
    public float DurationofText { get => _DurationofText; set => _DurationofText = value; }
}
