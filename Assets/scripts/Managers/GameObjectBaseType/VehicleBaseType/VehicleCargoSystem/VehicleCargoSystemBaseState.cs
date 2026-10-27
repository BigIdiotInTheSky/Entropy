using UnityEngine;

public abstract class VehicleCargoSystemBaseState
{
    protected VehicleCargoSystemStateManager vehicleCargoSystemStateManager;

    public VehicleCargoSystemBaseState(VehicleCargoSystemStateManager vehicleCargoSystemStateManager)
    {
        this.vehicleCargoSystemStateManager = vehicleCargoSystemStateManager;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
}
