using System.Collections.Generic;
using UnityEngine;

public class SMSStateManager
{
    private SMSBaseState currentState;
    private OnState onState;
    private OffState offState;
    public SMSBaseState CurrentState { get { return currentState; } }
    public OnState OnState { get { return onState; } }
    public OffState OffState{ get { return offState; } }
    public SMSStateManager(ShipMovementSystem shipMovementSystem)
    {
        offState = new OffState(this, shipMovementSystem.MoveThrusters, shipMovementSystem.RotateThrusters, shipMovementSystem.VTOLThrusters["upPos"]);
        onState = new OnState(this,  shipMovementSystem.MoveThrusters, shipMovementSystem.RotateThrusters, shipMovementSystem.VTOLThrusters["upPos"], shipMovementSystem.ShipManager);
        currentState = offState;
        currentState.EnterState();
    }
    public void MoveOn()
    {
        if (currentState != onState) { currentState = onState; }
        currentState.EnterState();
    }
    public void MoveOff()
    {
        if (currentState != offState) { currentState = offState; }
        currentState.EnterState();
    }
    public void ToggleOnOff()
    {
        if (currentState == onState) { MoveOff(); }
        else { MoveOn(); }
    }
}
