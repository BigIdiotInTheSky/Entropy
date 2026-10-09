using UnityEngine;

public class ShipLandingSystemDownState : ShipLandingSystemBaseState
{
    public ShipLandingSystemDownState (ShipLandingSystem shipLandingSystem) : base (shipLandingSystem) {}
    public override void EnterState()
    {
        ToggleGearAnims();
    }
}
