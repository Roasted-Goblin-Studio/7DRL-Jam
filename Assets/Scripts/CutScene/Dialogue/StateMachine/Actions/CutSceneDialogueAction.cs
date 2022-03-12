using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Cut Scene/Dialogue Action", fileName = "Dialogue")]
public class CutSceneDialogueAction : BaseAction
{
    [SerializeField] private List<Dialogue> _Dialogues;
    private float _TimeUntilNextDialogue = 0;
    private bool _DialogueRunning = false;

    public override void Act(BaseStateController controller)
    {    
        if(!_DialogueRunning){
            _DialogueRunning = true;
        }

        foreach (var Dialogue in _Dialogues)
        {
        }
    }
}
