using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : CharacterComponent
{
	// SETTINGS
	[Header("Basic")]
	[Range(0, .3f)] [SerializeField] private float _MovementSmoothing = .05f;	// How much to smooth out the movement 
	[Range(0, 10f)] [SerializeField] private float _MovementSpeed = 7.5f;
	[SerializeField] private bool _UseMovementFollow = false; 
    [SerializeField] private bool _FacingRight = true;     

	[Header("Movement Startup Lag")]
	[SerializeField] private float _MovementStartupLagLength = 0;
	[SerializeField] private float _MovementStartupLagDecrease = 0;
	[SerializeField] private bool _MovementStartupLag = false;
	
	[Header("Obstacle detection")]
	[Range(0, 10f)] [SerializeField] private float _ObstacleDetectionRange = 1.25f;
	[SerializeField] private List<LayerMask> _LayerMasksThatStopsGameObject;
	

	// PRIVATES
	private Vector2 _ObstacleBoxCheckSize = new Vector2(0, 0);
	private Vector3 _Velocity = Vector3.zero;
	private float _Horizontal;
	private float _Vertical;
	private float _MovementStartupLagEndTime;
	

	// PUBLICS
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
        _LayerMasksThatStopsGameObject.Add(LayerMask.GetMask("Walls"));
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
		if (_Character.CanMove == false) return;
		// Move the character by finding the target velocity

		float MovementSpeed = _MovementSpeed;
		if(_MovementStartupLag){
			_MovementStartupLagEndTime = Time.time + _MovementStartupLagLength;
			_MovementStartupLag = false;
		}

		if(Time.time < _MovementStartupLagEndTime){
			MovementSpeed /= _MovementStartupLagDecrease;
		}
		
		
		Vector3 targetVelocity = new Vector2(_Horizontal * MovementSpeed, _Vertical * MovementSpeed);

		// Check for Wall obstacles 
		if(DebugMode) Debug.DrawRay(_Character.CharacterHitbox.bounds.center, Vector3.ClampMagnitude(targetVelocity, _ObstacleDetectionRange), Color.green, 0, true);
		
		foreach (LayerMask layer in _LayerMasksThatStopsGameObject){ 
			RaycastHit2D layerHit = Physics2D.Raycast(_Character.CharacterHitbox.bounds.center, targetVelocity, _ObstacleDetectionRange, layer); 
			// Need to add the actual logic here but I'll come back to this.
			if(layerHit){
				_Horizontal = 0;
				_Vertical = 0;
			}
		}

		// Apply force
		targetVelocity = new Vector2(_Horizontal * MovementSpeed, _Vertical * MovementSpeed);
		// And then smoothing it out and applying it to the character
		_Character.RigidBody2D.velocity = Vector3.SmoothDamp(_Character.RigidBody2D.velocity, targetVelocity, ref _Velocity, _MovementSmoothing);
		
		if (_Character.CharacterType == Character.CharacterTypes.Player)
        {
            if (Horizontal > 0)
            {
                _Animator.SetFloat("velocity", 1);
                _Animator.SetBool("isMoving", FacingRight);
                _Animator.SetBool("isMovingReverse", !FacingRight);
            }
            else if (Horizontal < 0)
            {
                _Animator.SetFloat("velocity", 1);
                _Animator.SetBool("isMoving", !FacingRight);
                _Animator.SetBool("isMovingReverse", FacingRight);
            }
            else if (Vertical != 0)
            {
                _Animator.SetFloat("velocity", 1);
                _Animator.SetBool("isMoving", true);
                _Animator.SetBool("isMovingReverse", false);
            }
            else
            {
                _Animator.SetFloat("velocity", 0);
                _Animator.SetBool("isMoving", false);
                _Animator.SetBool("isMovingReverse", false);
            }
        }
		else
        {
            _Animator.SetBool("isMoving", Horizontal != 0 || Vertical != 0);
        }

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
		_Character.CanMove = true;
	}

	public void StopAllMovement(){
		Horizontal = 0;
		Vertical = 0;
	}

	// private void EvaluateObstacle()
    // {
    //     // Raycasting if obstacle collision in movement
    //     RaycastHit2D hit = Physics2D.BoxCast(_Character.CharacterHitbox.bounds.center, _ObstacleBoxCheckSize, 0f, _WanderDirection, _WanderDirection.magnitude, _ObstacleMask);
    //     Debug.DrawRay(_Character.CharacterHitbox.bounds.center, _WanderDirection);
    //     // If there is, pick a new direction
    //     if (hit)
    //     {
    //         _WanderDirection.x = Random.Range(-_WanderArea, _WanderArea);
    //         _WanderCheckTime = Time.time;
    //     }
    // }
}
