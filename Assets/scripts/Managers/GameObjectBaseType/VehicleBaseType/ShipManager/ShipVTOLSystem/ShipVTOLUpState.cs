using UnityEngine;

public class ShipVTOLUpState : ShipVTOLBaseState
{
    public ShipVTOLUpState (Animator animator) : base (animator) {}
    public override void EnterState() 
    {     
        animator.SetTrigger("VTOLUpDown");
        animator.SetBool("VTOLIsUp", true);
    }
}
