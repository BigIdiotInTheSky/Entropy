using UnityEngine;

public class VehicleCargoSystemStateManager
{
    private VehicleCargoSystemBaseState currentVehicleCargoSystemState;
    private VehicleCargoSystemLockedState vehicleCargoSystemLockedState;
    private VehicleCargoSystemUnlockedState vehicleCargoSystemUnlockedState;
    private VehicleCargoSystem vehicleCargoSystem;

    public VehicleCargoSystemBaseState CurrentVehicleCargoSystemState { get { return currentVehicleCargoSystemState; } set { currentVehicleCargoSystemState = value; currentVehicleCargoSystemState.EnterState(); } }
    public VehicleCargoSystemLockedState VehicleCargoSystemLockedState { get { return vehicleCargoSystemLockedState; } }
    public VehicleCargoSystemUnlockedState VehicleCargoSystemUnlockedState { get { return vehicleCargoSystemUnlockedState; } }
    public VehicleCargoSystem VehicleCargoSystem { get { return vehicleCargoSystem; } }
    public VehicleCargoSystemStateManager(VehicleCargoSystem vehicleCargoSystem)
    {
        this.vehicleCargoSystem = vehicleCargoSystem;
        vehicleCargoSystemLockedState = new VehicleCargoSystemLockedState(this);
        vehicleCargoSystemUnlockedState = new VehicleCargoSystemUnlockedState(this);
        currentVehicleCargoSystemState = vehicleCargoSystemUnlockedState;
    }
}
