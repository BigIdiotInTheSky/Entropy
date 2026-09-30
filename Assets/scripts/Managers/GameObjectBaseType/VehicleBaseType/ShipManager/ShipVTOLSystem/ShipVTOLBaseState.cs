
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipVTOLBaseState
{
    protected Animator animator;
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
        animator = shipVTOLSystem.Animator;
        vtolStateManager =  shipVTOLSystem.ShipManager.ShipMovementSystem.SMSStateManager.OnState.VTOLStateManager;
        this.vtolThrusters = vtolThrusters;
        this.shipVTOLSystem = shipVTOLSystem;
    }
    public abstract void EnterState();
    public abstract void UpdateState(Vector3 localV);
    protected void ToggleThrusterAnims()
    {
        animator.ResetTrigger("ToggleVTOL");
        animator.SetTrigger("ToggleVTOL");
    }
}
