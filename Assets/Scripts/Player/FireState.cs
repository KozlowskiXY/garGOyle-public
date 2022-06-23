using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : ShootingState
{
    public ShootingState doState(PlayerShooting player)
    {
        player.renderer.color = player.playerColor;
        player.ammo = player.defaultFire;
        
        if (player.waterbar.getWaterLevel() >=
            player.waterbar.getReduceAmount())
            return player.chargedState;
        else
            return player.fireState;
    }
    
}
