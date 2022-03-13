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

    [Header("SpawnManagers")]
    [SerializeField]  private SpawnManager _SpawnManager;
    public SpawnManager SpawnManager { get => _SpawnManager; set => _SpawnManager = value; }

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
        GameObject CutSceneManagerGameObject = GameObject.Find("CutScene Manager");
        GameObject SpawnManagerGameObject = GameObject.Find("SpawnManager");
        _Player = GameObject.Find("Player");
        if(CutSceneManagerGameObject != null) CutSceneManager = CutSceneManagerGameObject.GetComponent<CutSceneManager>();
        if(SpawnManagerGameObject != null) SpawnManager = SpawnManagerGameObject.GetComponent<SpawnManager>();  
    }

    protected override void HandleLowPriorityTasks(){
        base.HandleLowPriorityTasks();
    }

    public void LoadNextState(){
        GameObject playerSpawnPointGameObject = GameObject.Find("Player SpawnPoint");
        RoomHasCutScene = false;
        
        if(playerSpawnPointGameObject != null && _Player != null) _Player.transform.position = playerSpawnPointGameObject.transform.position; 

    }
    
}
