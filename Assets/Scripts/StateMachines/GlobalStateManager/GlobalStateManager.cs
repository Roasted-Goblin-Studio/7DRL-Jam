using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : BaseStateController
{
    // Room control
    [Header("Room Control")]
    [SerializeField] private bool _RoomIsActive = false;
    public bool RoomIsActive { get => _RoomIsActive; set => _RoomIsActive = value; }

    [Header("CutScene")]
    [SerializeField] private bool _RoomHasCutScene = false;
    private bool _CutSceneIsPlaying = false;
    private CutSceneManager _CutSceneManager;
    public bool RoomHasCutScene { get => _RoomHasCutScene; set => _RoomHasCutScene = value; }
    public CutSceneManager CutSceneManager { get => _CutSceneManager; set => _CutSceneManager = value; }

    [Header("EnemySpawners")]
    [SerializeField]  private EnemySpawner _EnemySpawner;
    public EnemySpawner EnemySpawner { get => _EnemySpawner; set => _EnemySpawner = value; }

    [Header("Pause Menu")]
    private bool _GameIsPaused = false;
    private bool _InPauseMenu = false;
    public bool GameIsPaused { get => _GameIsPaused; set => _GameIsPaused = value; }
    public bool InPauseMenu { get => _InPauseMenu; set => _InPauseMenu = value; }

    [Header("Player")]
    private GameObject _Player;
    public GameObject Player { get => _Player; set => _Player = value; }

    protected override void HandleStartTasks()
    {
        base.HandleStartTasks();
        CutSceneManager = GameObject.Find("CutScene Manager").GetComponent<CutSceneManager>();
        EnemySpawner = GameObject.Find("Snail-1.Spawn").GetComponent<EnemySpawner>();  
        _Player = GameObject.Find("Player");
    }

    protected override void HandleLowPriorityTasks(){
        base.HandleLowPriorityTasks();
    }
    
}
