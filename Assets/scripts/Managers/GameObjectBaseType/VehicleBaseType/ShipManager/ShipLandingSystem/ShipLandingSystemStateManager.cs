using UnityEngine;

public class ShipLandingSystemStateManager
{
    private ShipLandingSystemBaseState currentShipLandingState;
    private ShipLandingSystemDownState shipLandingSystemDownState;
    private ShipLandingSystemUpState shipLandingSystemUpState;
    private ShipLandingSystem shipLandingSystem;

    public ShipLandingSystemBaseState CurrentShipLandingState { get { return currentShipLandingState; } }
    public ShipLandingSystemDownState ShipLandingSystemDownState { get { return shipLandingSystemDownState; } }
    public ShipLandingSystemUpState ShipLandingSystemUpState { get { return shipLandingSystemUpState; } }
    public ShipLandingSystemStateManager(ShipLandingSystem shipLandingSystem)
    {
        shipLandingSystemDownState = new ShipLandingSystemDownState(shipLandingSystem);
        shipLandingSystemUpState = new ShipLandingSystemUpState(shipLandingSystem);
        currentShipLandingState = shipLandingSystemDownState;
        shipLandingSystemDownState.InitState();
        this.shipLandingSystem = shipLandingSystem;
    }

    public void ToggleGearUpDown()
    {
        if (currentShipLandingState == shipLandingSystemDownState)
            if (shipLandingSystemDownState.CurrentShipLandingSystemSubstate == shipLandingSystemDownState.ShipLandingSystemLockedSubstate)
            {
                Debug.Log("Unlock to raise gear!");
                return;
            }
            else { currentShipLandingState = shipLandingSystemUpState; }

        else { currentShipLandingState = shipLandingSystemDownState; }
        currentShipLandingState.EnterState();
    }

    public void ToggleGearLock()
    {
        if (currentShipLandingState == shipLandingSystemDownState && shipLandingSystem.PadContact == true)
        {
            if (shipLandingSystemDownState.CurrentShipLandingSystemSubstate == shipLandingSystemDownState.ShipLandingSystemLockedSubstate)
            {
                shipLandingSystemDownState.CurrentShipLandingSystemSubstate = shipLandingSystemDownState.ShipLandingSystemUnlockedSubstate;
            }
            else { shipLandingSystemDownState.CurrentShipLandingSystemSubstate = shipLandingSystemDownState.ShipLandingSystemLockedSubstate; }
        }
        else { Debug.Log("Bad lock"); }
    }
}
