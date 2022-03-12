using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSkull : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;

        var playerHP = collision.GetComponentInParent<CharacterHealth>();
        var playerAnimator = collision.GetComponent<Animator>();
        if (playerHP) playerHP.Heal(1);
        if (playerAnimator) playerAnimator.SetTrigger("HeadGrow");

    }
}
