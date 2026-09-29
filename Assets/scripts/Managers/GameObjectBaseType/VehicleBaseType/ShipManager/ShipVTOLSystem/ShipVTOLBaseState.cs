
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipVTOLBaseState
{
    protected Animator animator;
    protected Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersUp;
    protected Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersDown;
    public ShipVTOLBaseState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersUp, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersDown)
    {
        this.animator = animator;
        this.vtolThrustersUp = vtolThrustersUp;
        this.vtolThrustersDown = vtolThrustersDown;
    }
    public abstract void EnterState();
    protected void ToggleThrusterAnims()
    {
        animator.ResetTrigger("ToggleVTOL");
        animator.SetTrigger("ToggleVTOL");
    }
}
