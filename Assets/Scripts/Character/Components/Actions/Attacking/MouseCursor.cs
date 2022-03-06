using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : CharacterComponent
{
    private Vector3 _MousePosition;
    private GameObject _Cursor;
    public bool _LockMouseMovement;

    public Vector3 MousePosition { get => _MousePosition; set => _MousePosition = value; }
    public bool LockMouseMovement { get => _LockMouseMovement; set => _LockMouseMovement = value; }

    protected override void Start()
    {
        base.Start();
        _Cursor = GameObject.Find("Cursor");
    }

    override protected void HandlePhysicsComponentFunction(){
        if(!LockMouseMovement) SetCursorToFollowMouse();
        CursorIsToLeftOfPlayer();
    }
    
    private void SetCursorToFollowMouse(){
        _MousePosition = Input.mousePosition;
        _MousePosition.z +=10;
        _MousePosition = Camera.main.ScreenToWorldPoint(_MousePosition);
        _Cursor.transform.position = _MousePosition;
    }

    public void CursorIsToLeftOfPlayer(){
        if (_MousePosition.x < transform.position.x && _CharacterMovement.FacingRight) _CharacterMovement.Flip();
        else if(_MousePosition.x > transform.position.x && !_CharacterMovement.FacingRight) _CharacterMovement.Flip(); 
    }

    public Vector3 GetClampedDirectionofMouse(){
        return Vector3.ClampMagnitude(_MousePosition, 1);
    }
}
