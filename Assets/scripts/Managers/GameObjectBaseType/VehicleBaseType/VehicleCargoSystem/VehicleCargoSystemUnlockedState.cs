using UnityEngine;

public class VehicleCargoSystemUnlockedState : VehicleCargoSystemBaseState
{
    public VehicleCargoSystemUnlockedState(VehicleCargoSystemStateManager vehicleCargoSystemStateManager) : base (vehicleCargoSystemStateManager) {}

    public override void EnterState()
    {
        vehicleCargoSystemStateManager.VehicleCargoSystem.ContainerCollider.transform.SetParent(null);
    }
    public override void UpdateState() {}
}
