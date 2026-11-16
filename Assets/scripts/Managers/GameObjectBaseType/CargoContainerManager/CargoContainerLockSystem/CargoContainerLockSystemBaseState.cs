using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CargoContainerBaseState
{
    protected CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager;
    protected Rigidbody rigidbody;

    public CargoContainerBaseState(CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager)
    {
        this.cargoContainerLockSystemStateManager = cargoContainerLockSystemStateManager;
        rigidbody = cargoContainerLockSystemStateManager.CargoContainerLockSystem.GetComponent<Rigidbody>();
    }
    public abstract void EnterState();

    public abstract void UpdateState();
}
