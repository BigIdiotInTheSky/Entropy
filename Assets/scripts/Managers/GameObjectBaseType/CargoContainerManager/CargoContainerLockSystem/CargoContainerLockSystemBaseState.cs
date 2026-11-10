using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CargoContainerBaseState
{
    protected CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager;
    protected GameObject parentGameObject;

    public GameObject ParentGameObject { get { return parentGameObject; } set { parentGameObject = value; } }
    public CargoContainerBaseState(CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager)
    {
        this.cargoContainerLockSystemStateManager = cargoContainerLockSystemStateManager;
    }
    public abstract void EnterState();
}
