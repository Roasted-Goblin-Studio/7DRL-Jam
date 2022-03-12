using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject.Find("Player").transform.position = gameObject.transform.position;
    }
}
