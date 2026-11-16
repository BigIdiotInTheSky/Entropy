using UnityEngine;

public class CargoContainerLockSystem : MonoBehaviour
{
    private CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager;
    private CargoSystemBaseType cargoSystemBaseType;
    
    public CargoContainerLockSystemStateManager CargoContainerLockSystemStateManager { get { return cargoContainerLockSystemStateManager; } }
    public CargoSystemBaseType CargoSystemBaseType { get { return cargoSystemBaseType; } set { cargoSystemBaseType = value; } }

    void Start()
    {
        cargoContainerLockSystemStateManager = new CargoContainerLockSystemStateManager(this);
    }
}
