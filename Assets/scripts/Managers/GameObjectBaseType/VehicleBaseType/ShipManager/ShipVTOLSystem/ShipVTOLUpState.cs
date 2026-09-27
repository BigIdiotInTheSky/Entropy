using UnityEngine;

public class ShipVTOLUpState : ShipVTOLBaseState
{
    public ShipVTOLUpState (Animator animator) : base (animator) {}
    public override void EnterState() { ToggleThrusterAnims(); }
}
