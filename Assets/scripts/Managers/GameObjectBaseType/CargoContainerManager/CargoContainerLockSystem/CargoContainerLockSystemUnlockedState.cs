using UnityEngine;

public class CargoContainerLockSystemUnlockedState : CargoContainerBaseState
{
    public CargoContainerLockSystemUnlockedState(CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager) : base (cargoContainerLockSystemStateManager) {}

    public override void EnterState()
    {
        cargoContainerLockSystemStateManager.CargoContainerLockSystem.transform.localPosition = new Vector3(0,0,5);
        cargoContainerLockSystemStateManager.CargoContainerLockSystem.transform.SetParent(null);
        rigidbody.detectCollisions = true;
        rigidbody.constraints = RigidbodyConstraints.None;
    }

    public override void UpdateState() {}
}
