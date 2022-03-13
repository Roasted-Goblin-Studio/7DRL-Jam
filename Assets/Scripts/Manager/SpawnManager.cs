using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _EnemySpawners;
    public List<EnemySpawner> EnemySpawners { get => _EnemySpawners; set => _EnemySpawners = value; }

    private bool _SpawnEnemyEnabled = false;
    public bool SpawnEnemyEnabled { get=> _SpawnEnemyEnabled; set=> _SpawnEnemyEnabled = value; }

    public void StartSpawners(){
        if(SpawnEnemyEnabled) return; // Runs once
        SpawnEnemyEnabled = true;
        foreach (var spawner in _EnemySpawners)
        {
            spawner.SpawnEnemyEnabled = true;
        }
    }
}
