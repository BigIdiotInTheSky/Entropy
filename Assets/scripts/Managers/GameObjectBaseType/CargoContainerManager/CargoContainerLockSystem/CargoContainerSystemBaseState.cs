using UnityEngine;

public abstract class CargoContainerBaseState
{
    protected CargoContainerSystemStateManager cargoContainerSystemStateManager;

    public CargoContainerBaseState(CargoContainerSystemStateManager cargoContainerSystemStateManager)
    {
        this.cargoContainerSystemStateManager = cargoContainerSystemStateManager;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
}
