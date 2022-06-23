using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShootingState
{  
   // The accessible behavior in a certain state and the transition to other states
   ShootingState doState(PlayerShooting player);
}
