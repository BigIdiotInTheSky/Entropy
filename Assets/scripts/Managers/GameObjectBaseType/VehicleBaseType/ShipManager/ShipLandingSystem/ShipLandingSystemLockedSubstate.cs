using Unity.VisualScripting;
using UnityEngine;

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
        shipLandingSystemDownState.ShipLandingSystem.ShipManager.Rb.freezeRotation = true;
        shipLandingSystemDownState.ShipLandingSystem.ShipManager.Rb.maxLinearVelocity = 0;
        shipLandingSystemDownState.ShipLandingSystem.PositionConstraint.locked = true;
        shipLandingSystemDownState.ShipLandingSystem.transform.SetParent(shipLandingSystemDownState.ShipLandingSystem.PadCollider.transform);
    }
}
