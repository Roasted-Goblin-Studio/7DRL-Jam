using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Global/Playing", fileName = "Playing")]
public class GlobalPlayingAction : GlobalAction
{
    protected override void GlobalAct(GlobalStateManager controller)
    {
        // Add Enemy Spawn start
        if(!controller.EnemySpawner.SpawnEnemyEnabled) controller.EnemySpawner.SpawnEnemyEnabled = true;
    }
}
