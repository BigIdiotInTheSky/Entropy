using UnityEngine;

public class ShipLandingSystemUnlockedSubstate : ShipLandingSystemBaseSubstate
{
    public ShipLandingSystemUnlockedSubstate(ShipLandingSystemDownState shipLandingSystemDownState, Rigidbody rigidbody, GameObject gameObject) : base (shipLandingSystemDownState, rigidbody, gameObject) {}
    public override void EnterState()
    {
        Debug.Log("Gear unlocked");
        Unlock();
    }
    private void Unlock()
    {
        rigidbody.WakeUp();
        gameObject.transform.SetParent(shipLandingSystemDownState.ShipLandingSystem.Collider.transform);
    }
}