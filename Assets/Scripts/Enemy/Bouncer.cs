using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField] float _knockbackSpeed = 50f;

    protected override void PlayerImpact(Player player)
    {
        base.PlayerImpact(player);

        Vector3 moveDirection = player.transform.position - transform.position;

        player.Knockback(moveDirection.normalized, _knockbackSpeed);
    }
}
