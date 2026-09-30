using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class OffState : SMSBaseState
{
    public OffState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters, 
        Dictionary<string,List<ThrusterEffectInfo>> vtolThrusters) : base(sMSStateManager, moveThrusters, rotateThrusters, vtolThrusters) {}
    public override void UpdateState() {}
    public override void EnterState() { ToggleThrusters(false); }
}
