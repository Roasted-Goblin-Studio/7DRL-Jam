using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateObject : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _EnemySpawners;
    public List<EnemySpawner> EnemySpawners { get => _EnemySpawners; set => _EnemySpawners = value; }
}
