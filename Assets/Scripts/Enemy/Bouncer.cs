using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField] float _knockbackSpeed = 50f;

    protected override void PlayerImpact(Player player)
    {
        Vector3 moveDirection = player.transform.position - transform.position;

        //base.PlayerImpact(player);
        player.Knockback(moveDirection.normalized, _knockbackSpeed);
    }
}
