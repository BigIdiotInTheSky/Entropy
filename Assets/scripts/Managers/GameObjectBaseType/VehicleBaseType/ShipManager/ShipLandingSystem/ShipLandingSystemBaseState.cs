using UnityEngine;

public abstract class ShipLandingSystemBaseState
{
    protected ShipLandingSystem shipLandingSystem;

    public ShipLandingSystem ShipLandingSystem { get { return shipLandingSystem; } }
    public ShipLandingSystemBaseState (ShipLandingSystem shipLandingSystem)
    {
        this.shipLandingSystem = shipLandingSystem;
    }

    public abstract void EnterState();
    public abstract void InitState();
    protected void ToggleGearAnims()
    {
        shipLandingSystem.Animator.ResetTrigger("ToggleGear");
        shipLandingSystem.Animator.SetTrigger("ToggleGear");
    }
}
