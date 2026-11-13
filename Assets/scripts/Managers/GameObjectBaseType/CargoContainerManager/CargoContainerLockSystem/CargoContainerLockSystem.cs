using UnityEngine;

public class CargoContainerLockSystem : MonoBehaviour
{
    private CargoContainerManager cargoContainerManager;
    private CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager;
    
    public CargoContainerManager CargoContainerManager { get { return cargoContainerManager; } }
    public CargoContainerLockSystemStateManager CargoContainerLockSystemStateManager { get { return cargoContainerLockSystemStateManager; } }
    void Start()
    {
        cargoContainerManager = GetComponent<CargoContainerManager>();
        cargoContainerLockSystemStateManager = new CargoContainerLockSystemStateManager(this);
    }
}
