using UnityEngine;

public class ShipVTOLDownState : ShipVTOLBaseState
{
    public ShipVTOLDownState (Animator animator) : base (animator) {}
    public override void EnterState() { ToggleThrusterAnims(); }
}
