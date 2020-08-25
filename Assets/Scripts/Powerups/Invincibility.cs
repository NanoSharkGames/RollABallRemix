﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    protected override void PowerUp(Player player)
    {
        player.ActivateInvinciblity();
    }

    protected override void PowerDown(Player player)
    {
        player.DeactivateInvinciblity();
    }
}