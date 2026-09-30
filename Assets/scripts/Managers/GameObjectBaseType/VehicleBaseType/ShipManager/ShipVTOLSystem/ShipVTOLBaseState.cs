
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipVTOLBaseState
{
    protected Animator animator;
    protected Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters;
    protected StateManager vtolStateManager;
    public ShipVTOLBaseState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrusters, StateManager vtolStateManager)
    {
        this.animator = animator;
        this.vtolThrusters = vtolThrusters;
        this.vtolStateManager = vtolStateManager;
    }
    public abstract void EnterState();
    public abstract void UpdateState(Vector3 moveActionValue, float localV, Transform trans);
    protected void ToggleThrusterAnims()
    {
        animator.ResetTrigger("ToggleVTOL");
        animator.SetTrigger("ToggleVTOL");
    }
}
