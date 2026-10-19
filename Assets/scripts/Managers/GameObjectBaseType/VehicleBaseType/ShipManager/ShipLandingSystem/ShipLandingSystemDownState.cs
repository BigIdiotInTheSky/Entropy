using UnityEngine;

public class ShipLandingSystemDownState : ShipLandingSystemBaseState
{
    ShipLandingSystemBaseSubstate currentShipLandingSystemSubstate;
    ShipLandingSystemLockedSubstate shipLandingSystemLockedSubstate;
    ShipLandingSystemUnlockedSubstate shipLandingSystemUnlockedSubstate;

    public ShipLandingSystemBaseSubstate CurrentShipLandingSystemSubstate { get { return currentShipLandingSystemSubstate; } set { if (value != currentShipLandingSystemSubstate) { 
        currentShipLandingSystemSubstate = value; currentShipLandingSystemSubstate.EnterState(); } } }
    public ShipLandingSystemLockedSubstate ShipLandingSystemLockedSubstate { get { return shipLandingSystemLockedSubstate; }}
    public ShipLandingSystemUnlockedSubstate ShipLandingSystemUnlockedSubstate { get { return shipLandingSystemUnlockedSubstate; } }
    public ShipLandingSystemDownState (ShipLandingSystem shipLandingSystem) : base (shipLandingSystem)
    {
        shipLandingSystemLockedSubstate = new ShipLandingSystemLockedSubstate(this, shipLandingSystem.ShipManager.Rb, shipLandingSystem.ShipManager.gameObject);
        shipLandingSystemUnlockedSubstate = new ShipLandingSystemUnlockedSubstate(this, shipLandingSystem.ShipManager.Rb, shipLandingSystem.ShipManager.gameObject);
        currentShipLandingSystemSubstate = shipLandingSystemUnlockedSubstate;
    }
    public override void EnterState()
    {
        ToggleGearAnims();
    }
}