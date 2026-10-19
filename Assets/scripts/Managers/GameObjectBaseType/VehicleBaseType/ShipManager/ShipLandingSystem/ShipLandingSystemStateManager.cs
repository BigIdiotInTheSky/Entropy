using UnityEngine;

public class ShipLandingSystemStateManager
{
    private ShipLandingSystemBaseState currentShipLandingState;
    private ShipLandingSystemDownState shipLandingSystemDownState;
    private ShipLandingSystemUpState shipLandingSystemUpState;

    public ShipLandingSystemStateManager(ShipLandingSystem shipLandingSystem)
    {
        shipLandingSystemDownState = new ShipLandingSystemDownState(shipLandingSystem);
        shipLandingSystemUpState = new ShipLandingSystemUpState(shipLandingSystem);
        currentShipLandingState = shipLandingSystemDownState;
    }

    public void ToggleGearUpDown()
    {
        if (currentShipLandingState == shipLandingSystemDownState)
            if (shipLandingSystemDownState.CurrentShipLandingSystemSubstate == shipLandingSystemDownState.ShipLandingSystemLockedSubstate)
            {
                Debug.Log("Unlock to raise gear!");
            }
            else { currentShipLandingState = shipLandingSystemUpState; }

        else { currentShipLandingState = shipLandingSystemDownState; }
        currentShipLandingState.EnterState();
    }
}
