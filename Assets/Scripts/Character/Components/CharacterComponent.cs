using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{

    protected Character _Character;
    protected CharacterAchievements _CharacterAchievements;
    protected CharacterInput _CharacterInput;

    public CharacterAchievements CharacterAchievements { get => _CharacterAchievements; set => _CharacterAchievements = value; }
    public CharacterInput CharacterInput { get => _CharacterInput; set => _CharacterInput = value; }

    protected virtual void Awake(){
        _Character = GetComponent<Character>();
        CharacterAchievements = GetComponent<CharacterAchievements>();
        CharacterInput = GetComponent<CharacterInput>();
    }

    protected virtual void Start(){

    }

    protected virtual void Update(){
        HandleInput();
        HandleBasicComponentFunction();
    }

    protected virtual void FixedUpdate(){
        HandlePhysicsComponentFunction();
    }

    protected virtual void HandleInput(){
        // HandlePlayerInput();
        // HandleAIInput();
    }

    protected virtual bool HandlePlayerInput(){
        return IsPlayer();
    }

    protected virtual bool HandleAIInput(){
       return IsAI();
    }

    protected virtual void HandleBasicComponentFunction(){

    }

    protected virtual void HandlePhysicsComponentFunction(){

    }

    protected virtual bool IsPlayer(){
        return _Character.CharacterType == Character.CharacterTypes.Player;
    }

    protected virtual bool IsAI(){
        return _Character.CharacterType == Character.CharacterTypes.AI;
    }
}
