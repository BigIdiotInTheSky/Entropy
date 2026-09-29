
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipVTOLBaseState
{
    protected Animator animator;
    protected Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters;
    protected StateManager vtolStateManager;
    protected ShipVTOLSystem shipVTOLSystem;
    public ShipVTOLBaseState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, StateManager vtolStateManager, ShipVTOLSystem shipVTOLSystem)
    {
        this.animator = animator;
        this.vtolThrusters = vtolThrusters;
        this.vtolStateManager = vtolStateManager;
        this.shipVTOLSystem = shipVTOLSystem;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    protected void ToggleThrusterAnims()
    {
        animator.ResetTrigger("ToggleVTOL");
        animator.SetTrigger("ToggleVTOL");
    }
}
