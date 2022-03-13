using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float _Speed = 0f;
    [SerializeField] protected float _ProjectileDamage = 1f;
    [SerializeField] protected ProjectileTypes _ProjectileType;
    [SerializeField] private LayerMask _FriendlyLayers;
    [SerializeField] private LayerMask _EnemyLayers;

    protected Collider2D _Collider2D;
    protected Rigidbody2D _ProjectileRigidBody2D;
    protected SpriteRenderer _ProjectileSpriteRender;
    protected Vector2 _ProjectileMovement;
    protected Character _ProjectileOwner;
    protected ReturnObjectToPool _ReturnObjectToPool;

    private float _StartingSpeed;

    public Vector2 Direction { get; set; }
    public Character ProjectileOwner { get => _ProjectileOwner; set => _ProjectileOwner = value; }
    public ProjectileTypes ProjectileType {get => _ProjectileType; set=> _ProjectileType = value; }

    public enum ProjectileTypes
    {
        Bullet,
        Beam,
        Falling
    }

    private void Awake() {
        _ProjectileRigidBody2D = GetComponent<Rigidbody2D>();
        _ProjectileSpriteRender = GetComponent<SpriteRenderer>();
        _Collider2D = GetComponent<Collider2D>();
        _ReturnObjectToPool = GetComponent<ReturnObjectToPool>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _StartingSpeed = _Speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate(){
        MoveProjectile();
    }

    protected virtual void MoveProjectile(){
        /// INHERITANCE REMINDER - FILL OUT
    }

    protected virtual void FlipProjectile(){
        _ProjectileSpriteRender.flipX = !_ProjectileSpriteRender.flipX;
    }

    public  virtual void SetDirection(Vector2 newDirection, Quaternion newRotation, bool isFacingRight=true){
        Direction = newDirection;
        if(!isFacingRight){
            FlipProjectile();
        }
        transform.rotation = newRotation;
    }

    public void Reset(){
        _ProjectileSpriteRender.flipX = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.tag);
        //Debug.Log("Cehck?1 ");
        if (_FriendlyLayers == (_FriendlyLayers | (1 << other.gameObject.layer))) return;
        //Debug.Log("Cehck2");
        if (_EnemyLayers == (_EnemyLayers | (1 << other.gameObject.layer)))
        {
            // allows overrides
            DoEnemyCollision(other);
        }

        // Debug.Log("Cehck?3");

        _ReturnObjectToPool.DestroyObject();
    }

    protected virtual void DoEnemyCollision(Collider2D other)
    {
        var enemyHP = other.GetComponentInParent<Health>();

        if (!enemyHP) return;

        enemyHP.Damage(_ProjectileDamage);
    }

    protected virtual void OnTriggerStay2D(Collider2D collider){

    }

    protected virtual void OnTriggerExit2D(Collider2D other) {
        
    }
}
