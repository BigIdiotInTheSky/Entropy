using System.Collections.Generic;
using UnityEngine;
public class ShipVTOLSystemStateManager
{
    private ShipVTOLBaseState currentShipVTOLState;
    private ShipVTOLDownState shipVTOLDownState;
    private ShipVTOLUpState shipVTOLUpState;

    public ShipVTOLBaseState CurrentShipVTOLState { get { return currentShipVTOLState; } }

    public ShipVTOLSystemStateManager(ShipVTOLSystem shipVTOLSystem)
    {
        shipVTOLDownState = new ShipVTOLDownState(shipVTOLSystem.ShipManager.ShipMovementSystem.VTOLThrusters["downPos"], shipVTOLSystem);
        shipVTOLUpState = new ShipVTOLUpState(shipVTOLSystem.ShipManager.ShipMovementSystem.VTOLThrusters["upPos"], shipVTOLSystem);
        currentShipVTOLState = shipVTOLUpState;
    }

    public void ToggleVTOLUpDown()
    {
        if (currentShipVTOLState == shipVTOLDownState) { currentShipVTOLState = shipVTOLUpState; }
        else { currentShipVTOLState = shipVTOLDownState; }
        currentShipVTOLState.EnterState(); 
    }
}
