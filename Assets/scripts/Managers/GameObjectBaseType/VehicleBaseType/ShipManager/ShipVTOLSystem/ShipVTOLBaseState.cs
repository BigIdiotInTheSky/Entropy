
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipVTOLBaseState
{
    protected Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters;
    protected StateManager vtolStateManager;
    protected ShipVTOLSystem shipVTOLSystem;
    protected float moveActionValue;
    protected float localv;
    protected Vector3 trans;

    public float MoveActionValue { get { return moveActionValue; } }
    public float LocalV { get { return localv; } } 
    public Vector3 Trans { get { return trans; } }
    public ShipVTOLBaseState (Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, ShipVTOLSystem shipVTOLSystem)
    {
        vtolStateManager =  shipVTOLSystem.ShipManager.ShipMovementSystem.SMSStateManager.OnState.VTOLStateManager;
        this.vtolThrusters = vtolThrusters;
        this.shipVTOLSystem = shipVTOLSystem;
    }
    public abstract void EnterState();
    public abstract void UpdateState(Vector3 localV);
    protected void ToggleThrusterAnims()
    {
        shipVTOLSystem.Animator.ResetTrigger("ToggleVTOL");
        shipVTOLSystem.Animator.SetTrigger("ToggleVTOL");
    }

    protected void ToggleDampen(bool doDampen)
    {
        vtolStateManager.PositiveAccelerationState.Dampen = doDampen;
        vtolStateManager.NegativeAccelerationState.Dampen = doDampen;
        vtolStateManager.IdleState.Dampen = doDampen;
    }
}
