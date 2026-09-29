using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLDownState : ShipVTOLBaseState
{
    public ShipVTOLDownState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, StateManager vtolStateManager, ShipVTOLSystem shipVTOLSystem) : base (animator, vtolThrusters, vtolStateManager, shipVTOLSystem) {}
    public override void EnterState() 
    {
        ToggleThrusterAnims();
        vtolStateManager.PositiveAccelerationState.Dampen = true;
        vtolStateManager.NegativeAccelerationState.Dampen = true;
        vtolStateManager.PositiveAccelerationState.MoveThrusters = vtolThrusters["upThrusters"];
        vtolStateManager.NegativeAccelerationState.MoveThrusters = vtolThrusters["downThrusters"];
    }
    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
