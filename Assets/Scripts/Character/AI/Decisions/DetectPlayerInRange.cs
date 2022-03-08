using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Detect Target", fileName = "DecisionDetect")]
public class DetectPlayerInRange : AIDecision
{
    private float _DetectArea = 3f;

    private Collider2D _TargetCollider;
    private LayerMask _TargetMask;

    public override bool Decide(StateController controller)
    {
        return CheckTarget(controller);
    }

    private bool CheckTarget(StateController controller)
    {
        _TargetCollider = Physics2D.OverlapCircle(controller.transform.position, _DetectArea, _TargetMask);
        //_CurrentMovementSpeed = controller._CharacterMovement.HorizontalMovement;
        if (_TargetCollider == null || controller.Target == null) return false;
        controller.Target = _TargetCollider.transform;
        return true;
    }
}
