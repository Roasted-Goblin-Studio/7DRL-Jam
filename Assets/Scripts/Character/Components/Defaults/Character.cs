using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Character State.
    
    [SerializeField] protected CharacterTypes _CharacterType;

    protected Rigidbody2D _RigidBody2D;

    public CharacterTypes CharacterType { get => _CharacterType; set => _CharacterType = value; }
    public Rigidbody2D RigidBody2D { get => _RigidBody2D; set => _RigidBody2D = value; }

    // Enums
    public enum CharacterTypes {
        Inactive,
        Player,
        AI
    }

    protected virtual void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start() {
        
    }
}
