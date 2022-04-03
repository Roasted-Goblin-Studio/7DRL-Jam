using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string _TargetScene;
    [SerializeField] private Transform _SpawnPoint;
    private GlobalStateManager _GlobalStateManager;

    private void Start() {
        GameObject GlobalStateManagerGameObject = GameObject.Find("GlobalStateManager");
        if(GlobalStateManagerGameObject != null) _GlobalStateManager = GlobalStateManagerGameObject.GetComponent<GlobalStateManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") LoadScene();
    }

    private void LoadScene()
    {
        // add fader
        SceneManager.LoadScene(_TargetScene);
        if(_GlobalStateManager != null) _GlobalStateManager.LoadNextState();
        // Debug.Log(SceneManager.GetActiveScene().name);
        // if (_SpawnPoint) gameObject.transform.position = _SpawnPoint.position;
    }
}
