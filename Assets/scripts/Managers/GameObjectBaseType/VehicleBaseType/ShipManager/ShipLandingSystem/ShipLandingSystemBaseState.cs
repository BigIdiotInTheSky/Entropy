using UnityEngine;

public abstract class ShipLandingSystemBaseState
{
    protected ShipLandingSystem shipLandingSystem;

    public ShipLandingSystemBaseState (ShipLandingSystem shipLandingSystem)
    {
        this.shipLandingSystem = shipLandingSystem;
    }

    public abstract void EnterState();

    protected void ToggleGearAnims()
    {
        shipLandingSystem.Animator.ResetTrigger("ToggleGear");
        shipLandingSystem.Animator.SetTrigger("ToggleGear");
    }
}
