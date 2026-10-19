using UnityEngine;

public class ShipLandingSystemUnlockedSubstate : ShipLandingSystemBaseSubstate
{
    public override void EnterState()
    {
        Debug.Log("Gear unlocked");
    }
}
