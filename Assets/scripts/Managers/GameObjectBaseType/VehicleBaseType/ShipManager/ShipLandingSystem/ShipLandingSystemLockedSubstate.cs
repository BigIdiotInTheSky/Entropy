using Unity.VisualScripting;
using UnityEngine;

public class ShipLandingSystemLockedSubstate : ShipLandingSystemBaseSubstate
{
    public ShipLandingSystemLockedSubstate(ShipLandingSystemDownState shipLandingSystemDownState, Rigidbody rigidbody, GameObject gameObject) : base (shipLandingSystemDownState, rigidbody, gameObject) {}
    public override void EnterState()
    {
        Debug.Log("Gear locked");
        Lock();
    }
    private void Lock()
    {
        rigidbody.Sleep();
        gameObject.transform.SetParent(shipLandingSystemDownState.ShipLandingSystem.Collider.transform);
    }
}
