using Unity.VisualScripting;
using UnityEngine;

public class CargoContainerSystemLockedState : CargoContainerBaseState
{
    private Rigidbody rigidbody;
    public CargoContainerSystemLockedState(CargoContainerSystemStateManager cargoContainerSystemStateManager) : base (cargoContainerSystemStateManager) {}

    public override void EnterState()
    {
        // rigidbody = cargoContainerSy.VehicleCargoSystem.ContainerCollider.GetComponent<Rigidbody>();
        // rigidbody.detectCollisions = false;
        // rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        // cargoContainerLockSystem.VehicleCargoSystem.ContainerCollider.transform.SetParent(vehicleCargoSystemStateManager.VehicleCargoSystem.transform);
    }
    public override void UpdateState()
    {
        // rigidbody.rotation = cargoContainerLockSystem.VehicleCargoSystem.VehicleManager.Rb.rotation;
    }
}
