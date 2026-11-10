using UnityEngine;

public class CargoContainerLockSystemUnlockedState : CargoContainerBaseState
{
    public CargoContainerLockSystemUnlockedState(CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager) : base (cargoContainerLockSystemStateManager) {}

    public override void EnterState()
    {
        // vehicleCargoSystemStateManager.VehicleCargoSystem.ContainerCollider.transform.SetParent(null);
    }
}
