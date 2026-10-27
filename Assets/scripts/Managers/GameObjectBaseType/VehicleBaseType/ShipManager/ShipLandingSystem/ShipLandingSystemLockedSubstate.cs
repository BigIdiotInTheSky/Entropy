using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class ShipLandingSystemLockedSubstate : ShipLandingSystemBaseSubstate
{
    public ShipLandingSystemLockedSubstate(ShipLandingSystemDownState shipLandingSystemDownState) : base (shipLandingSystemDownState) {}
    public override void EnterState()
    {
        Debug.Log("Gear locked");
        Lock();
    }
    private void Lock()
    {
        shipLandingSystemDownState.ShipLandingSystem.ShipManager.ShipMovementSystem.SMSStateManager.MoveOff();
        shipLandingSystemDownState.ShipLandingSystem.transform.SetParent(shipLandingSystemDownState.ShipLandingSystem.PadCollider.transform);
    }
}
