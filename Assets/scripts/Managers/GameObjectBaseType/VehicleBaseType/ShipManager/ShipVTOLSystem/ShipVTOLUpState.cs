using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLUpState : ShipVTOLBaseState
{
    public ShipVTOLUpState (Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, ShipVTOLSystem shipVTOLSystem) : base (vtolThrusters, shipVTOLSystem) {}
    public override void EnterState() 
    { 
        ToggleThrusterAnims();
        vtolStateManager.PositiveAccelerationState.MoveThrusters = vtolThrusters["foreThrusters"];
        vtolStateManager.NegativeAccelerationState.MoveThrusters = vtolThrusters["aftThrusters"];
        ToggleDampen(false);
    }
    public override void UpdateState(Vector3 localV)
    {
        moveActionValue = shipVTOLSystem.ShipManager.ShipControlSystem.CurrentControlType.MoveOutput.z;
        localv = localV.z;
        trans = shipVTOLSystem.ShipManager.Trans.forward;
    }
}
