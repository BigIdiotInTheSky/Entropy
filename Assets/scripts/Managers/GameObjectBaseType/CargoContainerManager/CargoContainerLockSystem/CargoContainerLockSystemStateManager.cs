using UnityEngine;

public class CargoContainerLockSystemStateManager
{
    private CargoContainerBaseState currentCargoContainerSystemState;
    private CargoContainerSystemLockedState cargoContainerSystemLockedState;
    private CargoContainerLockSystemUnlockedState cargoContainerLockSystemUnlockedState;
    private CargoContainerLockSystem cargoContainerLockSystem;

    public CargoContainerBaseState CurrentCargoContainerSystemState { get { return currentCargoContainerSystemState; } set { currentCargoContainerSystemState = value; currentCargoContainerSystemState.EnterState(); } }
    public CargoContainerSystemLockedState CargoContainerSystemLockedState { get { return cargoContainerSystemLockedState; } }
    public CargoContainerLockSystemUnlockedState CargoContainerSystemUnlockedState { get { return cargoContainerLockSystemUnlockedState; } }
    public CargoContainerLockSystem CargoContainerLockSystem { get { return cargoContainerLockSystem; } }
    public CargoContainerLockSystemStateManager(CargoContainerLockSystem cargoContainerLockSystem)
    {
        this.cargoContainerLockSystem = cargoContainerLockSystem;
        cargoContainerSystemLockedState = new CargoContainerSystemLockedState(this);
        cargoContainerLockSystemUnlockedState = new CargoContainerLockSystemUnlockedState(this);
        currentCargoContainerSystemState = cargoContainerLockSystemUnlockedState;
    }

    public void UpdateState()
    {
        currentCargoContainerSystemState.UpdateState();
    }
    public void JettisonCargo()
    {
        if (currentCargoContainerSystemState == cargoContainerSystemLockedState)
        {
            currentCargoContainerSystemState = cargoContainerLockSystemUnlockedState;
            currentCargoContainerSystemState.EnterState();
        }
    }
}
