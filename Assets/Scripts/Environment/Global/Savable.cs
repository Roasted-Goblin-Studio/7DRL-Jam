using System.Collections;
using UnityEngine;

public class Savable : MonoBehaviour
{
    // objects with this script attached will persist on scene changes

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}