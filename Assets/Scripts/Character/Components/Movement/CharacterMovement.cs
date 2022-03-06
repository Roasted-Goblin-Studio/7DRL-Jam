using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : CharacterComponent
{
	[Range(0, .3f)] [SerializeField] private float _MovementSmoothing = .05f;	// How much to smooth out the movement 
	
    private bool _FacingRight = true;       // For determining which way the player is currently facing.      
    Vector3 Velocity = Vector3.zero;
	private float _MovementSpeed = 7.5f; 


	protected override void Awake()
	{
		base.Awake();
	}

    protected override void Start()
    {
        base.Start();
        //Initialising the force to use on the RigidBody in various ways
    }

    protected override void HandlePhysicsComponentFunction()
    {
        MoveCharacter();

    }

    public void MoveCharacter()
	{
            float Horizontal = Input.GetAxisRaw("Horizontal");
            float Vertical = Input.GetAxisRaw("Vertical");
        
            // Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(Horizontal * _MovementSpeed, Vertical * _MovementSpeed);
			// And then smoothing it out and applying it to the character
			_Character.RigidBody2D.velocity = Vector3.SmoothDamp(_Character.RigidBody2D.velocity, targetVelocity, ref Velocity, _MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (Horizontal > 0 && !_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (Horizontal < 0 && _FacingRight)
			{
				// ... flip the player.
				Flip();
			}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_FacingRight = !_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
