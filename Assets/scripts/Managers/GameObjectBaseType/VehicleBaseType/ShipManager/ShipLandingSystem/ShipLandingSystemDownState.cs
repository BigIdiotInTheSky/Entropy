using UnityEngine;

public class ShipLandingSystemDownState : ShipLandingSystemBaseState
{
    ShipLandingSystemBaseSubstate currentShipLandingSystemSubstate;
    ShipLandingSystemLockedSubstate shipLandingSystemLockedSubstate;
    ShipLandingSystemUnlockedSubstate shipLandingSystemUnlockedSubstate;

    public ShipLandingSystemBaseSubstate CurrentShipLandingSystemSubstate { get { return currentShipLandingSystemSubstate; } }
    public ShipLandingSystemLockedSubstate ShipLandingSystemLockedSubstate { get { return shipLandingSystemLockedSubstate; }}
    public ShipLandingSystemDownState (ShipLandingSystem shipLandingSystem) : base (shipLandingSystem)
    {
        shipLandingSystemLockedSubstate = new ShipLandingSystemLockedSubstate();
        shipLandingSystemUnlockedSubstate = new ShipLandingSystemUnlockedSubstate();
        currentShipLandingSystemSubstate = shipLandingSystemUnlockedSubstate;
    }
    public override void EnterState()
    {
        ToggleGearAnims();
    }
    public void ToggleGear()
    {
        if (currentShipLandingSystemSubstate == shipLandingSystemLockedSubstate) { currentShipLandingSystemSubstate = shipLandingSystemUnlockedSubstate; }
        else { currentShipLandingSystemSubstate = shipLandingSystemLockedSubstate; }
        currentShipLandingSystemSubstate.EnterState();
    }
}