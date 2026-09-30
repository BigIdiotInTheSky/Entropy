using UnityEngine;


public class ShipManager : VehicleTypeBase
{
    [SerializeField] private ShipProfile shipProfile;
    private ShipMovementSystem shipMovementSystem;
    private ShipControlSystem shipControlSystem;
    private ShipVTOLSystem shipVTOLSystem;
    // private ShipLandingSystem shipLandingSystem;

    public ShipProfile ShipProfile { get { return shipProfile; } }
    public ShipMovementSystem ShipMovementSystem { get { return shipMovementSystem; } }
    public ShipControlSystem ShipControlSystem { get { return shipControlSystem; } }
    public ShipVTOLSystem ShipVTOLSystem { get { return shipVTOLSystem;} }
    // public ShipLandingSystem ShipLandingSystem { get { return ShipLandingSystem; } }
    void Awake()
    {
        shipMovementSystem = GetComponent<ShipMovementSystem>();
        shipControlSystem = GetComponent<ShipControlSystem>();
        shipVTOLSystem = GetComponent<ShipVTOLSystem>();
    }
}
