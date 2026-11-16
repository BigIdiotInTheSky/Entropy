using UnityEngine;

public abstract class CargoSystemBaseType : MonoBehaviour
{
    [Header("Cargo Grid")]
    [SerializeField, Range(1,100)] private int xGridSize;
    [SerializeField, Range(1,100)] private int yGridSize;
    [SerializeField, Range(1,100)] private int zGridSize;
    protected GameObjectBaseType gameObjectBaseType;
    protected CargoContainerLockSystem[,,] containerGrid;
    protected Rigidbody rigidbody;
    protected Transform containerMarker;

    public Transform ContainerMarker { get { return containerMarker; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjectBaseType = GetComponent<GameObjectBaseType>();
        rigidbody = GetComponent<Rigidbody>();
        containerGrid = new CargoContainerLockSystem[xGridSize,yGridSize,zGridSize];
        containerMarker = transform.Find("ContainerMarker");
        if (!containerMarker) { throw new System.Exception("ContainerMarker not found"); }   
    }
    void OnTriggerEnter(Collider collider)
    {
        CargoContainerLockSystem cargoContainerLockSystem = collider.GetComponent<CargoContainerLockSystem>();
        Debug.Log(cargoContainerLockSystem);
        if(cargoContainerLockSystem)
        {
            for (int i = 0; i < containerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < containerGrid.GetLength(1); j++)
                {
                    for (int k = 0; k < containerGrid.GetLength(2); k++)
                    {
                        if (containerGrid[i,k,j] == null)
                        {
                            int[] index = {i,k,j};
                            containerGrid[i,k,j] = cargoContainerLockSystem;
                            cargoContainerLockSystem.CargoSystemBaseType = this;
                            CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager = cargoContainerLockSystem.CargoContainerLockSystemStateManager;
                            cargoContainerLockSystemStateManager.CargoContainerSystemLockedState.ContainerIndex = index;
                            cargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = cargoContainerLockSystemStateManager.CargoContainerSystemLockedState;
                        }
                    }
                }
            }
        }
    }

    public void JettisonCargo()
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
                        cargoContainerLockSystem.CargoContainerLockSystemStateManager.JettisonCargo();
                        containerGrid[i,k,j] = null;
                    }
                }
            }
        }
    }
}
