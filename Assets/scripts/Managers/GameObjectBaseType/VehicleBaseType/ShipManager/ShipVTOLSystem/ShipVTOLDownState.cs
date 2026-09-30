using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLDownState : ShipVTOLBaseState
{
    public ShipVTOLDownState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, StateManager vtolStateManager) : base (animator, vtolThrusters, vtolStateManager) {}
    public override void EnterState() 
    {
        ToggleThrusterAnims();
        vtolStateManager.PositiveAccelerationState.Dampen = true;
        vtolStateManager.NegativeAccelerationState.Dampen = true;
        vtolStateManager.PositiveAccelerationState.MoveThrusters = vtolThrusters["upThrusters"];
        vtolStateManager.NegativeAccelerationState.MoveThrusters = vtolThrusters["downThrusters"];
    }
    public override void UpdateState(Vector3 moveActionValue, float localV, Transform trans)
    {

    }
}
