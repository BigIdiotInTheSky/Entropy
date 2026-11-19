using UnityEngine;

public class CargoContainerLockSystem : MonoBehaviour
{
    private CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager;
    private CargoSystemBaseType cargoSystemBaseType;
    private BoxCollider containerCollider;
    
    public CargoContainerLockSystemStateManager CargoContainerLockSystemStateManager { get { return cargoContainerLockSystemStateManager; } }
    public CargoSystemBaseType CargoSystemBaseType { get { return cargoSystemBaseType; } set { cargoSystemBaseType = value; } }
    public BoxCollider ContainerCollider { get { return containerCollider; } }

    void Start()
    {
        containerCollider = GetComponent<BoxCollider>();
        if (!containerCollider) { throw new System.Exception("collider not found"); }
        cargoContainerLockSystemStateManager = new CargoContainerLockSystemStateManager(this);
    }
}
