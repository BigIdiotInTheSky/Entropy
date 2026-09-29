using System.Collections.Generic;
using UnityEngine;

public class ShipVTOLDownState : ShipVTOLBaseState
{
    public ShipVTOLDownState (Animator animator, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersUp, Dictionary<string, List<ThrusterEffectInfo>> vtolThrustersDown) : base (animator, vtolThrustersUp, vtolThrustersDown) {}
    public override void EnterState() { ToggleThrusterAnims(); }
}
