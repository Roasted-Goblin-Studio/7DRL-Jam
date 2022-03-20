using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Global State Manager/Actions/Playing", fileName = "Playing")]
public class GlobalPlayingAction : GlobalAction
{
    protected override void GlobalAct(GlobalStateManager controller)
    {
        // Starts up Enemy Spawners

        if(controller.SpawnManager == null) return;
        if(!controller.SpawnManager.SpawnEnemyEnabled) controller.SpawnManager.StartSpawners();
    }
}
