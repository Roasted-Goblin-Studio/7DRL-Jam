using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/General/Follow", fileName = "Follow")]
public class FollowAction : AIAction
{
    [SerializeField] [Range(0, 10)] private float _MinDistanceToFollowHorizontally = 0;
    [SerializeField] [Range(0, 10)] private float _MinDistanceToFollowVertically = 0;

    public override void Act(StateController controller)
    {
        FollowTarget(controller);
    }

    private void FollowTarget(StateController controller){
        if(controller.Target == null) return;

        // Horizontal Follow
        if(controller.transform.position.x < controller.Target.position.x) controller.CharacterMovement.Horizontal = 1;
        else controller.CharacterMovement.Horizontal = -1;

        // Vertical Follow
        if(controller.transform.position.y < controller.Target.position.y) controller.CharacterMovement.Vertical = 1;
        else controller.CharacterMovement.Vertical = -1;
        
        //If follow distance is reached stop
        if(Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < _MinDistanceToFollowHorizontally) controller.CharacterMovement.Horizontal = 0;
        if(Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < _MinDistanceToFollowVertically) controller.CharacterMovement.Vertical = 0;
    }
}
