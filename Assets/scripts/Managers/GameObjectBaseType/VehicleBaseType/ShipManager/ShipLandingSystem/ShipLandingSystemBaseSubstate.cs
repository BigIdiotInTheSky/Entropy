using UnityEngine;

public abstract class ShipLandingSystemBaseSubstate
{
    protected ShipLandingSystemDownState shipLandingSystemDownState;
    protected Rigidbody rigidbody;
    protected GameObject gameObject;

    public ShipLandingSystemBaseSubstate (ShipLandingSystemDownState shipLandingSystemDownState,  Rigidbody rigidbody, GameObject gameObject)
    {
        this.shipLandingSystemDownState = shipLandingSystemDownState;
        this.gameObject = gameObject;
        this.rigidbody = rigidbody;
    }
    public abstract void EnterState();
}
