using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Movement/Wander", fileName = "Wander")]
public class AIBasicWanderAction : AIBasicAction
{
    [SerializeField] public float _WanderArea = 3f;
    [SerializeField] public float _WanderTime = 2f;
    [SerializeField] private bool _DebugMode = false;
    public float _WanderAreaNoMoveZone = 0.75f; // GameObjects treat absolute 0 poorly. This makes it so there is some lee-way when the final wander point is reached. 

    private Vector2 _WanderDirection;
    private float _WanderCheckTime = 0;

    public Vector2 _ObstacleBoxCheckSize = new Vector2(2, 2);
    public LayerMask _ObstacleMask;

    protected override void AIAct(AIBasicStateController controller)
    {
        Wander(controller);
        EvaluateObstacle(controller);
    }

    private void Wander(AIBasicStateController controller)
    {
        if (Time.time > _WanderCheckTime)
        {
            _WanderDirection.x = Random.Range(-_WanderArea, _WanderArea);
            _WanderDirection.y = Random.Range(-_WanderArea, _WanderArea);


            // If movement range is basically nothing, just remain still
            if (_WanderDirection.x < _WanderAreaNoMoveZone && _WanderDirection.x > -_WanderAreaNoMoveZone)
            {
                controller.CharacterMovement.Horizontal = 0;
                controller.CharacterMovement.Vertical = 0;
            }
            else
            {
                controller.CharacterMovement.Vertical = Mathf.Clamp(_WanderDirection.y, -.25f, .25f);
                controller.CharacterMovement.Horizontal = Mathf.Clamp(_WanderDirection.x, -.25f, .25f);
            }
            _WanderCheckTime = Time.time + _WanderTime;
        }
    }

    private void EvaluateObstacle(AIBasicStateController controller)
    {
        // Raycasting if obstacle collision in movement
        RaycastHit2D hit = Physics2D.BoxCast(controller.Character.CharacterHitbox.bounds.center, _ObstacleBoxCheckSize, 0f, _WanderDirection, _WanderDirection.magnitude, _ObstacleMask);
        if(_DebugMode) Debug.DrawRay(controller.Character.CharacterHitbox.bounds.center, _WanderDirection, Color.yellow);
        // If there is, pick a new direction
        if (hit)
        {
            _WanderDirection.x = Random.Range(-_WanderArea, _WanderArea);
            _WanderCheckTime = Time.time;
        }
    }

    void OnEnable()
    {
        _WanderCheckTime = 0;
    }
}
