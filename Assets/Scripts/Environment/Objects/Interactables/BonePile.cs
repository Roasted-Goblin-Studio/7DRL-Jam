using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePile : MonoBehaviour
{
    [SerializeField] private float _Cooldown = 1f;
    private float _TimeWhenBoneAvailable = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;
        if (Time.time >= _TimeWhenBoneAvailable) AddBone(collision.gameObject);
    }

    private void AddBone(GameObject player)
    {
        _TimeWhenBoneAvailable = Time.time + _Cooldown;
        var playerHP = player.GetComponentInParent<CharacterHealth>();
        playerHP.Heal(1);
    }
}
