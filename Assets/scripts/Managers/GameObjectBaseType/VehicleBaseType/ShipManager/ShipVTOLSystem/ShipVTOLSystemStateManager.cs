using System.Collections.Generic;
using UnityEngine;
public class ShipVTOLSystemStateManager
{
    private ShipVTOLBaseState currentShipVTOLState;
    private ShipVTOLDownState shipVTOLDownState;
    private ShipVTOLUpState shipVTOLUpState;

    public ShipVTOLSystemStateManager(Animator animator, Dictionary<string, Dictionary<string, List<ThrusterEffectInfo>>> vtolThrusters, StateManager vtolStateManager, ShipVTOLSystem shipVTOLSystem)
    {
        shipVTOLDownState = new ShipVTOLDownState(animator, vtolThrusters["downPos"], vtolStateManager, shipVTOLSystem);
        shipVTOLUpState = new ShipVTOLUpState(animator, vtolThrusters["upPos"], vtolStateManager, shipVTOLSystem);
        currentShipVTOLState = shipVTOLUpState;
    }

    public void ToggleVTOLUpDown()
    {
        if (currentShipVTOLState == shipVTOLDownState) { currentShipVTOLState = shipVTOLUpState; }
        else { currentShipVTOLState = shipVTOLDownState; }
        currentShipVTOLState.EnterState(); 
    }
}
