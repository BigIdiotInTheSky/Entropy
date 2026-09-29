using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLUpState : ShipVTOLBaseState
{
    public ShipVTOLUpState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersUp, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersDown) : base (animator, vtolThrustersDown, vtolThrustersUp) {}
    public override void EnterState() { ToggleThrusterAnims(); }
}
