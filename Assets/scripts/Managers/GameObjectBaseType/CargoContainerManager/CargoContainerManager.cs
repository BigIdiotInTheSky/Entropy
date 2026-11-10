using UnityEngine;

public class CargoContainerManager : GameObjectBaseType
{
    CargoContainerLockSystem cargoContainerLockSystem;
    public CargoContainerLockSystem CargoContainerLockSystem { get { return cargoContainerLockSystem; } }
    void Awake()
    {
        cargoContainerLockSystem = GetComponent<CargoContainerLockSystem>();
    }
}
