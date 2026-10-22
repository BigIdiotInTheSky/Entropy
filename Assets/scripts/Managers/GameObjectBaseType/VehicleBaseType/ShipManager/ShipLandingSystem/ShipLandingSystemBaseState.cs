using Unity.VisualScripting.FullSerializer;
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
    protected void ToggleGearCollision(bool doCollide)
    {
        for (int i = 0; i < shipLandingSystem.GearColliders.Count; i++)
        {
            shipLandingSystem.GearColliders[i].enabled = doCollide;
        }
    }
}
