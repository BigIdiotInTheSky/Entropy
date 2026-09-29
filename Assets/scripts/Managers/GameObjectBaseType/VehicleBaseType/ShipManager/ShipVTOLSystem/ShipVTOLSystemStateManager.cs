using System.Collections.Generic;
using UnityEngine;
public class ShipVTOLSystemStateManager
{
    private ShipVTOLBaseState currentShipVTOLState;
    private ShipVTOLDownState shipVTOLDownState;
    private ShipVTOLUpState shipVTOLUpState;

    public ShipVTOLSystemStateManager(ShipVTOLSystem shipVTOLSystem)
    {
        shipVTOLDownState = new ShipVTOLDownState(shipVTOLSystem.Animator, shipVTOLSystem.ShipManager.ShipMovementSystem.VTOLThrusters["downPos"], 
            shipVTOLSystem.ShipManager.ShipMovementSystem.SMSStateManager.OnState.VTOLStateManager, shipVTOLSystem);
        shipVTOLUpState = new ShipVTOLUpState(shipVTOLSystem.Animator, shipVTOLSystem.ShipManager.ShipMovementSystem.VTOLThrusters["upPos"], 
            shipVTOLSystem.ShipManager.ShipMovementSystem.SMSStateManager.OnState.VTOLStateManager, shipVTOLSystem);
        currentShipVTOLState = shipVTOLUpState;
    }

    public void ToggleVTOLUpDown()
    {
        if (currentShipVTOLState == shipVTOLDownState) { currentShipVTOLState = shipVTOLUpState; }
        else { currentShipVTOLState = shipVTOLDownState; }
        currentShipVTOLState.EnterState(); 
    }
}
