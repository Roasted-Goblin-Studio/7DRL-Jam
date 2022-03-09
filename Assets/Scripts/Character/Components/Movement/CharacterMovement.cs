using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : CharacterComponent
{
	[Range(0, .3f)] [SerializeField] private float _MovementSmoothing = .05f;	// How much to smooth out the movement 
	
    private bool _FacingRight = true; 
	private bool _UseMovementFollow = false;       // For determining which way the player is currently facing.      
    private Vector3 _Velocity = Vector3.zero;
	private float _MovementSpeed = 7.5f;

	private float _Horizontal;
	private float _Vertical;

	public bool FacingRight { get => _FacingRight; set => _FacingRight = value; }
	public bool UseMovementFollow { get => _UseMovementFollow; set => _UseMovementFollow = value; }
	public float Horizontal { get => _Horizontal; set => _Horizontal = value; }
	public float Vertical { get => _Vertical; set => _Vertical = value; }

	protected override void Awake()
	{
		base.Awake();
	}

    protected override void Start()
    {
        base.Start();
        //Initialising the force to use on the RigidBody in various ways
    }

    protected override void HandlePlayerInput()
    {
		Horizontal = Input.GetAxisRaw("Horizontal");
		Vertical = Input.GetAxisRaw("Vertical");
    }

    protected override void HandlePhysicsComponentFunction()
    {
        MoveCharacter();
    }

    public void MoveCharacter()
	{		
		if(_Character.CanMove == false) return;	
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(_Horizontal * _MovementSpeed, _Vertical * _MovementSpeed);
		// And then smoothing it out and applying it to the character
		_Character.RigidBody2D.velocity = Vector3.SmoothDamp(_Character.RigidBody2D.velocity, targetVelocity, ref _Velocity, _MovementSmoothing);

		if(UseMovementFollow){
			// If the input is moving the player right and the player is facing left...
			if (_Horizontal > 0 && !_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (_Horizontal < 0 && _FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
	}

	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		_FacingRight = !_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void LockMovement(){
		_Character.CanMove = false;
	}

	public void UnlockMovement(){
		_Character.CanMove = false;
	}

	public void StopAllMovement(){
		Horizontal = 0;
		Vertical = 0;
	}
}
