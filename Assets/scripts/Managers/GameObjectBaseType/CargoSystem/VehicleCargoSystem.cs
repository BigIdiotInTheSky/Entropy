
public class VehicleCargoSystem : CargoSystemBaseType
{
    void FixedUpdate()
    {
        for (int i = 0; i < containerGrid.GetLength(0); i++)
        {
            for (int j = 0; j < containerGrid.GetLength(1); j++)
            {
                for (int k = 0; k < containerGrid.GetLength(2); k++)
                {
                    CargoContainerLockSystem cargoContainerLockSystem = containerGrid[i,k,j];
                    if (cargoContainerLockSystem)
                    {
                        cargoContainerLockSystem.CargoContainerLockSystemStateManager.UpdateState();
                    }
                }
            }
        }
    }
}
