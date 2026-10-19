using UnityEngine;

public abstract class ShipLandingSystemBaseSubstate
{
    protected ShipLandingSystemDownState shipLandingSystemDownState;

    public ShipLandingSystemBaseSubstate (ShipLandingSystemDownState shipLandingSystemDownState)
    {
        this.shipLandingSystemDownState = shipLandingSystemDownState;
    }
    public abstract void EnterState();
}