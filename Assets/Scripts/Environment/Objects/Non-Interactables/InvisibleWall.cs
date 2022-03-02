using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{

    protected bool _IsActive = true;
    protected Collider2D _Collider;

    // Start is called before the first frame update
    void Start()
    {
        _Collider = GetComponent<Collider2D>();
    }

    public void DisableInvisibleWall(){
        _IsActive = false;
        _Collider.enabled = false;
        // Sprite should be disabled
    }
}
