using System.Collections.Generic;
using UnityEngine;

public class SMSStateManager
{
    private SMSBaseState currentState;
    private OnState onState;
    private OffState offState;
    private ShipMovementSystem shipMovementSystem;

    public SMSBaseState CurrentState { get { return currentState; } }
    public OnState OnState { get { return onState; } }
    public OffState OffState{ get { return offState; } }
    public ShipMovementSystem ShipMovementSystem { get { return shipMovementSystem; } }

    public SMSStateManager(ShipMovementSystem shipMovementSystem)
    {
        this.shipMovementSystem = shipMovementSystem;
        offState = new OffState(this, shipMovementSystem.MoveThrusters, shipMovementSystem.RotateThrusters, shipMovementSystem.VTOLThrusters["downPos"]);
        onState = new OnState(this,  shipMovementSystem.MoveThrusters, shipMovementSystem.RotateThrusters, shipMovementSystem.VTOLThrusters["downPos"]);
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
        if (shipMovementSystem.ShipManager.ShipLandingSystem.ShipLandingSystemStateManager.ShipLandingSystemDownState.CurrentShipLandingSystemSubstate == 
            shipMovementSystem.ShipManager.ShipLandingSystem.ShipLandingSystemStateManager.ShipLandingSystemDownState.ShipLandingSystemUnlockedSubstate)
        {
            if (currentState == onState) { MoveOff(); }
            else { MoveOn(); }
        }
        else { Debug.Log("Unlock to toogle thrusters!"); }
    }
}
