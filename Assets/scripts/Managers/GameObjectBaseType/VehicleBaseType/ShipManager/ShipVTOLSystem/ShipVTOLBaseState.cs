
using UnityEngine;

public abstract class ShipVTOLBaseState
{
    protected Animator animator;
    public ShipVTOLBaseState (Animator animator)
    {
        this.animator = animator;
    }
    public abstract void EnterState();
    protected void ToggleThrusterAnims()
    {
        animator.ResetTrigger("ToggleVTOL");
        animator.SetTrigger("ToggleVTOL");
    }
}
