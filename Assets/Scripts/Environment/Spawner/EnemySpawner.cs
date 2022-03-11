using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyObject;
    [SerializeField] private List<Transform> SpawnPositions;
    
    [SerializeField] private string _EnemyName;

    [SerializeField] private float _TimeBetweenSpawns = 0;
    [SerializeField] private bool _SpawnEnemies = true;
    private float _TimeUntilNextEnemy = 0;
 
    private GlobalStateManager _GlobalStateManager;


    // Start is called before the first frame update
    void Start()
    {
        _GlobalStateManager = GameObject.Find("GlobalStateManager").GetComponent<GlobalStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_GlobalStateManager.RoomIsActive && _SpawnEnemies) RunSpawner();
    }

    private void RunSpawner(){
        if(Time.time > _TimeUntilNextEnemy){
            _TimeUntilNextEnemy = Time.time + _TimeBetweenSpawns;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy(){
        foreach (var SpawnPosition in SpawnPositions)
        {
            Instantiate(EnemyObject, SpawnPosition);
        }
    }
}
