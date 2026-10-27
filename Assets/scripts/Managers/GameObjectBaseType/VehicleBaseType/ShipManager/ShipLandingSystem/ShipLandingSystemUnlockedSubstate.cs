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
        shipLandingSystemDownState.ShipLandingSystem.transform.SetParent(null);
    }
}