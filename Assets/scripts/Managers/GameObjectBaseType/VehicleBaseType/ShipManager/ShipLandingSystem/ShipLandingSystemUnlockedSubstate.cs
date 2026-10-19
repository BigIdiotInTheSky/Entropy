using UnityEngine;

public class ShipLandingSystemUnlockedSubstate : ShipLandingSystemBaseSubstate
{
    public ShipLandingSystemUnlockedSubstate(ShipLandingSystemDownState shipLandingSystemDownState) : base (shipLandingSystemDownState) {}
    public override void EnterState()
    {
        Debug.Log("Gear unlocked");
        Unlock();
    }
    private void Unlock()
    {
        shipLandingSystemDownState.ShipLandingSystem.ShipManager.Rb.freezeRotation = false;
        shipLandingSystemDownState.ShipLandingSystem.ShipManager.Rb.maxLinearVelocity = shipLandingSystemDownState.ShipLandingSystem.ShipManager.ShipProfile.MaxLinearVelocity / 10;
        shipLandingSystemDownState.ShipLandingSystem.PositionConstraint.locked = false;
        shipLandingSystemDownState.ShipLandingSystem.transform.SetParent(null);
    }
}