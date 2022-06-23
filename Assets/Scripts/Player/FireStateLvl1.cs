using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStateLvl1 : ShootingState
{
   public ShootingState doState(PlayerShooting player)
   {
      player.ammo = player.defaultFire;
      return player.fireStateLvl1;
   }
}
