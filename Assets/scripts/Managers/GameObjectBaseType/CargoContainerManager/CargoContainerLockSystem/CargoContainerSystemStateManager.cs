using UnityEngine;

public class CargoContainerSystemStateManager
{
    private CargoContainerBaseState currentCargoContainerSystemState;
    private CargoContainerSystemLockedState cargoContainerSystemLockedState;
    private CargoContainerSystemUnlockedState cargoContainerSystemUnlockedState;
    private CargoContainerLockSystem cargoContainerLockSystem;

    public CargoContainerBaseState CurrentCargoContainerSystemState { get { return currentCargoContainerSystemState; } set { currentCargoContainerSystemState = value; currentCargoContainerSystemState.EnterState(); } }
    public CargoContainerSystemLockedState CargoContainerSystemLockedState { get { return cargoContainerSystemLockedState; } }
    public CargoContainerSystemUnlockedState CargoContainerSystemUnlockedState { get { return cargoContainerSystemUnlockedState; } }
    public CargoContainerLockSystem CargoContainerLockSystem { get { return cargoContainerLockSystem; } }
    public CargoContainerSystemStateManager(CargoContainerLockSystem cargoContainerLockSystem)
    {
        this.cargoContainerLockSystem = cargoContainerLockSystem;
        cargoContainerSystemLockedState = new CargoContainerSystemLockedState(this);
        cargoContainerSystemUnlockedState = new CargoContainerSystemUnlockedState(this);
        currentCargoContainerSystemState = cargoContainerSystemUnlockedState;
    }
}
