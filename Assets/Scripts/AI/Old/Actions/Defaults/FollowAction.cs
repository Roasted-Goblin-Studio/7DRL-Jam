using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAction : AIAction
{
    [SerializeField] [Range(0, 10)] private float _MinDistanceToFollowHorizontally = 0;
    [SerializeField] [Range(0, 10)] private float _MinDistanceToFollowVertically = 0;
    [SerializeField] private bool _BackUpOnApproach = false;
    [SerializeField] [Range(0, 10)] private float _MinDistanceToStayAwayFromTarget = 0;
    private Transform _LastKnownLocation;

    public override void Act(StateController controller)
    {
        FollowTarget(controller);
    }

    private void FollowTarget(StateController controller){
        if(controller.Target == null) return;
        float horizontalMovement = 0;
        float verticalMovement = 0;

        // Horizontal Follow
        if(controller.transform.position.x < controller.Target.position.x) horizontalMovement = 1;
        else horizontalMovement = -1;

        // Vertical Follow
        if(controller.transform.position.y < controller.Target.position.y) verticalMovement = 1;
        else verticalMovement = -1;
        
        //If follow distance is reached stop
        if(Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < _MinDistanceToFollowHorizontally) horizontalMovement = 0;
        if(Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < _MinDistanceToFollowVertically) verticalMovement = 0;
    
        if(_BackUpOnApproach){
            if(Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < _MinDistanceToStayAwayFromTarget){
                if(controller.transform.position.x < controller.Target.position.x) horizontalMovement = -1;
                else horizontalMovement = 1;
            }
            if(Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < _MinDistanceToStayAwayFromTarget){
                if(controller.transform.position.y < controller.Target.position.y) verticalMovement = -1;
                else verticalMovement = 1;
            }
        }

        controller.CharacterMovement.Horizontal = horizontalMovement;
        controller.CharacterMovement.Vertical = verticalMovement;
    }
}
