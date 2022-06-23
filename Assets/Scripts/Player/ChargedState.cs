using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedState : ShootingState
{
    public ShootingState doState(PlayerShooting player)
    {   
        player.renderer.color = Color.blue;
        //player.ammo = player.chargedFire;
        
        if (player.waterbar.getWaterLevel() < player.waterbar.getReduceAmount())
            return player.fireState;
        else
            return player.chargedState;
    }
}
