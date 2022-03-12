using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Cut Scene/Dialogue Action", fileName = "Dialogue")]
public class CutSceneDialogueAction : BaseAction
{
    [SerializeField] private List<Dialogue> _Dialogues;
    private float _TimeUntilNextDialogue = 0;
    private float _TimeBetweenDialogues = 0;

    private bool _DialogueInit = false;
    private bool _DialogueRunning = false;
    private bool _DialogueTextRunning = false;
    private bool _DialogueFinished = false;
    

    private int DialogueIndex = 0;

    public override void Act(BaseStateController controller)
    {   
        CutSceneAct((CutSceneManager) controller);
    }


    public void CutSceneAct(CutSceneManager controller)
    {    
        if(_DialogueFinished) return;

        if(!_DialogueInit){
            // Initializing the CutScene
            _DialogueInit = true;
            foreach (var Dialogue in _Dialogues)
            {
                GameObject target = GameObject.Find(Dialogue.Target);
                if(target == null) return;
                if(Dialogue.TargetStartingOffset != new Vector3(0,0,0)) target.transform.position = controller.CutSceneStartingLocation.position + Dialogue.TargetStartingOffset;

                Character targetCharacter = target.GetComponent<Character>();
                if(targetCharacter != null){
                    // Lock Character
                    targetCharacter.Lock();
                    if(Dialogue.TargetFacingRight) targetCharacter.FaceRight();
                    else targetCharacter.FaceLeft();
                }
            }
        }

        if(!_DialogueRunning){
            _DialogueRunning = true;
            // GameObject target = GameObject.Find( _Dialogues[DialogueIndex].Target);
            // target.transform.position = controller.CutSceneStartingLocation.position + _Dialogues[DialogueIndex].TargetStartingOffset;
        }
        
        if(_DialogueRunning){
            if(!_DialogueTextRunning){
                _DialogueTextRunning = true;
                _TimeUntilNextDialogue = Time.time + _Dialogues[DialogueIndex].DurationofText;
                Debug.Log(_Dialogues[DialogueIndex].DialogueText);
            }
        }

        if(_DialogueTextRunning){
            if(Time.time > _TimeUntilNextDialogue){
                DialogueIndex++;
                _DialogueRunning = false;
                _DialogueTextRunning = false;
            }
        }

        if(DialogueIndex >= _Dialogues.Count) _DialogueFinished = true;

        if(_DialogueFinished){
            foreach (var Dialogue in _Dialogues)
            {
                GameObject target = GameObject.Find(Dialogue.Target);
                if(target == null) return;
                if(Dialogue.DestroyTargetOnFinish) Destroy(target);

                Character targetCharacter = target.GetComponent<Character>();
                if(targetCharacter != null){
                    // Lock Character
                    targetCharacter.Unlock();
                }
            } 
        }
    }


    void OnEnable()
    {
    _TimeUntilNextDialogue = 0;
    _TimeBetweenDialogues = 0;

    _DialogueInit = false;
    _DialogueRunning = false;
    _DialogueTextRunning = false;
    _DialogueFinished = false;

    DialogueIndex = 0;
    }
}
