using UnityEngine;

public class CargoContainerLockSystem : MonoBehaviour
{
    private bool containerContact;
    private CargoContainerManager cargoContainerManager;
    private CargoContainerSystemStateManager cargoContainerSystemStateManager;

    // public bool ContainerContact { get { return containerContact; } }
    public CargoContainerManager CargoContainerManager { get { return cargoContainerManager; } }
    void Start()
    {
        cargoContainerManager = GetComponent<CargoContainerManager>();
        cargoContainerSystemStateManager = new CargoContainerSystemStateManager(this);
    }
    void FixedUpdate()
    {
        // vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState.UpdateState();
    }
}
