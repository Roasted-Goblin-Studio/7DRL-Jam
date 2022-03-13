using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefab and SpawnPoint")]
    [SerializeField] private GameObject EnemyObject;
    [SerializeField] private List<Transform> SpawnPositions;
    
    [Header("General")]
    [SerializeField] private string _EnemyName;
    [SerializeField] private bool _SpawnEnemiesEnabled = false;
    [SerializeField] [Range(0, 15)] private float _MaxEnemiesSpawned;
    private float _NumberOfEnemiesSpawned = -1;
    public bool SpawnEnemyEnabled { get => _SpawnEnemiesEnabled; set => _SpawnEnemiesEnabled = value; }

    [Header("Timers")]
    [SerializeField] private float _TimeBetweenSpawns = 0;
    private float _TimeUntilNextEnemy = 0;

    [Header("Randomize Spawn Location")]
    [SerializeField] private bool _RandomizeEnemySpawnPoint;
    private int _RandomizeEnemeyLastSpawnIndex=0;

    // PRIVATES ;) 8==D
    private GlobalStateManager _GlobalStateManager;

    // Start is called before the first frame update
    void Start()
    {
        _GlobalStateManager = GameObject.Find("GlobalStateManager").GetComponent<GlobalStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_SpawnEnemiesEnabled) RunSpawner();
    }

    private void RunSpawner(){
        if(Time.time > _TimeUntilNextEnemy && _NumberOfEnemiesSpawned < _MaxEnemiesSpawned){
            _TimeUntilNextEnemy = Time.time + _TimeBetweenSpawns;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy(){
        if(_GlobalStateManager.GameIsPaused) return;
        if(_RandomizeEnemySpawnPoint){
            int RandomSelection = Random.Range(0, SpawnPositions.Count);
            if(RandomSelection == _RandomizeEnemeyLastSpawnIndex) RandomSelection++;
            if(RandomSelection > SpawnPositions.Count) RandomSelection = SpawnPositions.Count;

            Transform SpawnPosition = SpawnPositions[RandomSelection];
            
            GameObject clone = Instantiate(EnemyObject, SpawnPosition);
            clone.transform.parent = null;   

            _RandomizeEnemeyLastSpawnIndex = RandomSelection;  
            _NumberOfEnemiesSpawned+=1;
        }else{
            foreach (var SpawnPosition in SpawnPositions)
            {
                GameObject clone = Instantiate(EnemyObject, SpawnPosition);
                clone.transform.parent = null;
                _NumberOfEnemiesSpawned+=1;
            }
        }
    }
}
