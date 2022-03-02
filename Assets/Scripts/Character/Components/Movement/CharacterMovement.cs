using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponent
{
    // Serialized
    [SerializeField] private float _MovementSpeed;
    [SerializeField] private float _MaxSpeed;

    // Private
    private float _HorizontalMovement;
    private float _HorizontalForceApplied;
    private float _VerticalMovement;
    private float _VerticalForceApplied;
    private float _MovementCompoundValue = 1f;
    private float _ReverseForceApplied = 2f;
    private bool _ApplyReverseForce;

    // Public
    public float VerticalMovement { get => _VerticalMovement; set => _VerticalMovement = value; }
    public float HorizontalMovement { get => _HorizontalMovement; set => _HorizontalMovement = value; }
    public float MovementSpeed { get => _MovementSpeed; set => _MovementSpeed = value; }
    public float ReverseForceApplied { get => _ReverseForceApplied; set => _ReverseForceApplied = value; }
    public bool ApplyReverseForce { get => _ApplyReverseForce; set => _ApplyReverseForce = value; }
    
    protected override void HandlePhysicsComponentFunction(){
        CalcMovement();
    }

    protected override bool HandlePlayerInput()
    {   
        if(!base.HandlePlayerInput()) return false;
        return true;
    }

    private void CalcMovement(){
        CalcHorizontalMovement();
        CalcVerticalMovement();
        _Character.RigidBody2D.AddForce(new Vector2(_HorizontalForceApplied, _VerticalForceApplied), ForceMode2D.Impulse);
    }

    protected virtual void CalcHorizontalMovement(){
        // Both botton pressed results in 0
        if(Input.GetKey(CharacterInput.MovementLeftKeyCode) && Input.GetKey(CharacterInput.MovementRightKeyCode)){
            HorizontalMovement = 0;
        }
        // Left movement
        else if(Input.GetKey(CharacterInput.MovementLeftKeyCode)){
            HorizontalMovement += -_MovementCompoundValue;
        
        // Right movement
        }else if(Input.GetKey(CharacterInput.MovementRightKeyCode)){
            HorizontalMovement += _MovementCompoundValue;
        
        // Slowing / Stopped
        }else{
            //ApplyReverseForce = false;
            if(_Character.RigidBody2D.velocity.sqrMagnitude != 0){
                //Debug.Log("Slowing down");
                ApplyReverseForce = true;
                if(_Character.RigidBody2D.velocity.x < 0){
                    // Slow down left movement
                    HorizontalMovement += _MovementCompoundValue;
                }
                else if(_Character.RigidBody2D.velocity.x > 0){
                    // Slow down left movement
                    HorizontalMovement += -_MovementCompoundValue;
                }
            }
            else{
                HorizontalMovement = 0;
            } 
            
        }

        HorizontalMovement = Mathf.Clamp(HorizontalMovement, -_MaxSpeed, _MaxSpeed);
        //if(ApplyReverseForce) HorizontalMovement = HorizontalMovement * ReverseForceApplied;
        _HorizontalForceApplied = MovementSpeed * HorizontalMovement;
    }

    protected virtual void CalcVerticalMovement(){
        // Both botton pressed results in 0
        
        if(Input.GetKey(CharacterInput.MovementDownKeyCode) && Input.GetKey(CharacterInput.MovementUpKeyCode)){
            VerticalMovement = 0;
        }
        // Left movement
        else if(Input.GetKey(CharacterInput.MovementDownKeyCode)){
            VerticalMovement += -_MovementCompoundValue;
        
        // Right movement
        }else if(Input.GetKey(CharacterInput.MovementUpKeyCode)){
            VerticalMovement += _MovementCompoundValue;
        
        }else{
            if(_Character.RigidBody2D.velocity.sqrMagnitude <= -.1 || _Character.RigidBody2D.velocity.sqrMagnitude >= .1){


            //if(_Character.RigidBody2D.velocity.sqrMagnitude != 0){
                Debug.Log("Slowing down");
                if(_Character.RigidBody2D.velocity.y < 0){
                    // Slow down left movement
                    VerticalMovement += _MovementCompoundValue*2;
                }
                else if(_Character.RigidBody2D.velocity.y > 0){
                    // Slow down left movement
                    VerticalMovement += -_MovementCompoundValue*2;
                }

            }
            else{
                VerticalMovement = 0;
            } 
            
        }

        VerticalMovement = Mathf.Clamp(VerticalMovement, -_MaxSpeed, _MaxSpeed);
        _VerticalForceApplied = MovementSpeed * VerticalMovement;
    }
}
