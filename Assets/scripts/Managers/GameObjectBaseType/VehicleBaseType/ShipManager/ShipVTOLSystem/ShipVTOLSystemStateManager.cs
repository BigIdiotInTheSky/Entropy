using System.Collections.Generic;
using UnityEngine;
public class ShipVTOLSystemStateManager
{
    private ShipVTOLBaseState currentShipVTOLState;
    private ShipVTOLDownState shipVTOLDownState;
    private ShipVTOLUpState shipVTOLUpState;

    public ShipVTOLSystemStateManager(Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersDown, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersUp)
    {
        shipVTOLDownState = new ShipVTOLDownState(animator, vtolThrustersDown, vtolThrustersDown);
        shipVTOLUpState = new ShipVTOLUpState(animator, vtolThrustersDown, vtolThrustersUp);
        currentShipVTOLState = shipVTOLUpState;
    }

    public void ToggleVTOLUpDown()
    {
        if (currentShipVTOLState == shipVTOLDownState) { currentShipVTOLState = shipVTOLUpState; }
        else { currentShipVTOLState = shipVTOLDownState; }
        currentShipVTOLState.EnterState(); 
    }
}
