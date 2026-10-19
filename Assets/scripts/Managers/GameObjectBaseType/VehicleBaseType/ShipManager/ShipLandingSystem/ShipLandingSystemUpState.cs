using UnityEngine;

public class ShipLandingSystemUpState : ShipLandingSystemBaseState
{
    public ShipLandingSystemUpState (ShipLandingSystem shipLandingSystem) : base (shipLandingSystem) {}
    public override void EnterState()
    {
        ToggleGearAnims();
        shipLandingSystem.ShipManager.Rb.maxLinearVelocity = shipLandingSystem.ShipManager.ShipProfile.MaxLinearVelocity;

    }
    public override void InitState()
    {
        throw new System.NotImplementedException();
    }
}
