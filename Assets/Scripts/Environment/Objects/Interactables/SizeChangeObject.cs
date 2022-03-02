using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class SizeChangeObject : MonoBehaviour
{

    //  Greater than 1 to grow, Less than 1 to shrink.
    //  less than zero starts reversing the spriterender along the changed axis.
    [Tooltip("Must have an absolute value greater than zero")]
    [SerializeField] private float _sizeChangeScale = 1.5f;

    private BoxCollider2D _boxCollider2D;

    void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        float _posNegSign = other.gameObject.transform.root.localScale.x / Mathf.Abs(other.gameObject.transform.root.localScale.x);

        if (other.gameObject.transform.root.tag == "Player")
        {
            other.gameObject.transform.root.localScale = new Vector3( _sizeChangeScale * _posNegSign, _sizeChangeScale, _sizeChangeScale);
        }
        Destroy(gameObject);
    }
}