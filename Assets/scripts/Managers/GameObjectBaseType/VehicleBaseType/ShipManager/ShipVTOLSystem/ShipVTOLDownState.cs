using UnityEngine;

public class ShipVTOLDownState : ShipVTOLBaseState
{
    public ShipVTOLDownState (Animator animator) : base (animator) {}
    public override void EnterState()
    {
        animator.SetTrigger("VTOLUpDown");
        animator.SetBool("VTOLIsUp", false);
    }
}
