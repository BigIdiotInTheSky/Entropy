using UnityEngine;
using UnityEngine.UIElements;

public class ShipVTOLSystemStateManager
{
    private ShipVTOLBaseState currentShipVTOLState;
    private ShipVTOLDownState shipVTOLDownState;
    private ShipVTOLUpState shipVTOLUpState;

    // public ShipVTOLBaseState CurrentShipVTOLState { get { return currentShipVTOLState; } set { currentShipVTOLState = value; currentShipVTOLState.EnterState(); } }
    // public ShipVTOLDownState ShipVTOLDownState { get { return shipVTOLDownState; } }
    // public ShipVTOLUpState ShipVTOLUpState { get { return shipVTOLUpState; } }

    public ShipVTOLSystemStateManager(Animator animator)
    {
        shipVTOLDownState = new ShipVTOLDownState(animator);
        shipVTOLUpState = new ShipVTOLUpState(animator);
        currentShipVTOLState = shipVTOLUpState;
    }

    public void ToggleVTOLUpDown()
    {
        if (currentShipVTOLState == shipVTOLDownState) { currentShipVTOLState = shipVTOLUpState; }
        else { currentShipVTOLState = shipVTOLDownState; }
        currentShipVTOLState.EnterState(); 
    }
}
