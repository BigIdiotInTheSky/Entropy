using UnityEngine;

public class ShipLandingSystemDownState : ShipLandingSystemBaseState
{
    private ShipLandingSystemBaseSubstate currentShipLandingSystemSubstate;
    private ShipLandingSystemLockedSubstate shipLandingSystemLockedSubstate;
    private ShipLandingSystemUnlockedSubstate shipLandingSystemUnlockedSubstate;

    public ShipLandingSystemBaseSubstate CurrentShipLandingSystemSubstate { get { return currentShipLandingSystemSubstate; } set { if (value != currentShipLandingSystemSubstate) { 
        currentShipLandingSystemSubstate = value; currentShipLandingSystemSubstate.EnterState(); } } }
    public ShipLandingSystemLockedSubstate ShipLandingSystemLockedSubstate { get { return shipLandingSystemLockedSubstate; }}
    public ShipLandingSystemUnlockedSubstate ShipLandingSystemUnlockedSubstate { get { return shipLandingSystemUnlockedSubstate; } }
    public ShipLandingSystemDownState (ShipLandingSystem shipLandingSystem) : base (shipLandingSystem)
    {
        shipLandingSystemLockedSubstate = new ShipLandingSystemLockedSubstate(this);
        shipLandingSystemUnlockedSubstate = new ShipLandingSystemUnlockedSubstate(this);
        currentShipLandingSystemSubstate = shipLandingSystemUnlockedSubstate;
        currentShipLandingSystemSubstate.EnterState();
    }
    public override void EnterState()
    {
        ToggleGearAnims();
        ToggleGearCollision(true);
        shipLandingSystem.ShipManager.Rb.maxLinearVelocity = shipLandingSystem.ShipManager.ShipProfile.MaxLinearVelocity;
    }
    public override void InitState()
    {
        shipLandingSystem.ShipManager.Rb.maxLinearVelocity = shipLandingSystem.ShipManager.ShipProfile.MaxLinearVelocity;
    }
}