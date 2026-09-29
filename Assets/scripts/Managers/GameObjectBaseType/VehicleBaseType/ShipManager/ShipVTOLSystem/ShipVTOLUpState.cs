using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLUpState : ShipVTOLBaseState
{
    public ShipVTOLUpState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, StateManager vtolStateManager, ShipVTOLSystem shipVTOLSystem) : base (animator, vtolThrusters, vtolStateManager, shipVTOLSystem) {}
    public override void EnterState() 
    { 
        ToggleThrusterAnims();
        vtolStateManager.PositiveAccelerationState.Dampen = false;
        vtolStateManager.NegativeAccelerationState.Dampen = false;
        vtolStateManager.PositiveAccelerationState.MoveThrusters = vtolThrusters["foreThrusters"];
        vtolStateManager.NegativeAccelerationState.MoveThrusters = vtolThrusters["aftThrusters"];
    }
    public override void UpdateState()
    {
        // shipVTOLSystem.MoveActionValue =
    }
}
