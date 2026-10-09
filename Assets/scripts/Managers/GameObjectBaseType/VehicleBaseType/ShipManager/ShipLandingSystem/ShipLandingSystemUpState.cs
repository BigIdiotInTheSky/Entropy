using UnityEngine;

public class ShipLandingSystemUpState : ShipLandingSystemBaseState
{
    public ShipLandingSystemUpState (ShipLandingSystem shipLandingSystem) : base (shipLandingSystem) {}
    public override void EnterState()
    {
        ToggleGearAnims();
    }
}
