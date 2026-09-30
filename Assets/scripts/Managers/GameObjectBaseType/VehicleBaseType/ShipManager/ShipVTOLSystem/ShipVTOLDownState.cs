using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLDownState : ShipVTOLBaseState
{
    public ShipVTOLDownState (Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, ShipVTOLSystem shipVTOLSystem) : base (vtolThrusters, shipVTOLSystem) {}
    public override void EnterState() 
    {
        ToggleThrusterAnims();
        vtolStateManager.PositiveAccelerationState.Dampen = true;
        vtolStateManager.NegativeAccelerationState.Dampen = true;
        vtolStateManager.PositiveAccelerationState.MoveThrusters = vtolThrusters["upThrusters"];
        vtolStateManager.NegativeAccelerationState.MoveThrusters = vtolThrusters["downThrusters"];
    }
    public override void UpdateState(Vector3 localV)
    {
        moveActionValue = shipVTOLSystem.ShipManager.ShipControlSystem.CurrentControlType.MoveOutput.y;
        localv = localV.y;
        trans = shipVTOLSystem.ShipManager.Trans.up;
    }
}
