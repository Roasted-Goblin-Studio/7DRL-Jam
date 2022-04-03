using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private Collider2D _Collider2D;
    // Start is called before the first frame update
    void Start()
    {
        _Collider2D = GetComponent<Collider2D>();
    }

    public void EnableCollider(){
        _Collider2D.enabled = true;
    }
    public void DisableCollider(){
        _Collider2D.enabled = false;
    }
}
