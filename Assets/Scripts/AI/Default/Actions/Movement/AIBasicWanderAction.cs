using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Movement/Wander", fileName = "Wander")]
public class AIBasicWanderAction : AIBasicAction
{
    [SerializeField] public float _WanderArea = 3f;
    [SerializeField] public float _WanderTime = 2f;
    [SerializeField] public float _WaitTime = 2f;
    [SerializeField] private bool _DebugMode = false;
    public float _WanderAreaNoMoveZone = 0.75f; // GameObjects treat absolute 0 poorly. This makes it so there is some lee-way when the final wander point is reached. 

    public Vector2 _ObstacleBoxCheckSize = new Vector2(2, 2);
    public LayerMask _ObstacleMask;

    protected override void AIAct(AIBasicStateController controller)
    {
        Wander(controller);
        EvaluateObstacle(controller);
    }

    private void Wander(AIBasicStateController controller)
    {   
        if (Time.time > controller.ActionCheckTime)
        {
            controller.ActionTarget.x = Random.Range(-_WanderArea, _WanderArea);
            controller.ActionTarget.y = Random.Range(-_WanderArea, _WanderArea);

            // If movement range is basically nothing, just remain still
            if (controller.ActionTarget.x < _WanderAreaNoMoveZone && controller.ActionTarget.x > -_WanderAreaNoMoveZone)
            {
                controller.CharacterMovement.Horizontal = 0;
                controller.CharacterMovement.Vertical = 0;
            }
            else
            {
                controller.CharacterMovement.Vertical = Mathf.Clamp(controller.ActionTarget.y, -.25f, .25f);
                controller.CharacterMovement.Horizontal = Mathf.Clamp(controller.ActionTarget.x, -.25f, .25f);
            }
            controller.ActionCheckTime = Time.time;
        }
    }

    private void EvaluateObstacle(AIBasicStateController controller)
    {
        // Raycasting if obstacle collision in movement
        RaycastHit2D hit = Physics2D.BoxCast(controller.Character.CharacterHitbox.bounds.center, _ObstacleBoxCheckSize, 0f, controller.ActionTarget, controller.ActionTarget.magnitude, _ObstacleMask);
        if(_DebugMode) Debug.DrawRay(controller.Character.CharacterHitbox.bounds.center, controller.ActionTarget, Color.yellow);
        // If there is, pick a new direction
        if (hit)
        {
            controller.ActionTarget.x = Random.Range(-_WanderArea, _WanderArea);
            controller.ActionCheckTime = Time.time;
        }
    }
}
