using Unity.VisualScripting;
using UnityEngine;

public class CargoContainerSystemLockedState : CargoContainerBaseState
{
    private Rigidbody rigidbody;
    public CargoContainerSystemLockedState(CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager) : base (cargoContainerLockSystemStateManager) {}

    public override void EnterState()
    {
        rigidbody = cargoContainerLockSystemStateManager.CargoContainerLockSystem.GetComponent<Rigidbody>();
        rigidbody.detectCollisions = false;
        // rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
