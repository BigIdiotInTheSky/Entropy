using UnityEngine;

public class ShipLandingSystemLockedSubstate : ShipLandingSystemBaseSubstate
{
    public override void EnterState()
    {
        Debug.Log("Gear locked");
    }
}
