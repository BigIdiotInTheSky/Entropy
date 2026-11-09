using UnityEngine;

public class CargoContainerSystemUnlockedState : CargoContainerBaseState
{
    public CargoContainerSystemUnlockedState(CargoContainerSystemStateManager cargoContainerSystemStateManager) : base (cargoContainerSystemStateManager) {}

    public override void EnterState()
    {
        // vehicleCargoSystemStateManager.VehicleCargoSystem.ContainerCollider.transform.SetParent(null);
    }
    public override void UpdateState() {}
}
