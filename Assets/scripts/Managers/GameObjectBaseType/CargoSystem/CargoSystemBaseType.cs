using UnityEngine;

public abstract class CargoSystemBaseType : MonoBehaviour
{
    [Header("Cargo Grid")]
    [SerializeField, Range(1,100)] protected int xGridSize;
    [SerializeField, Range(1,100)] protected int yGridSize;
    [SerializeField, Range(1,100)] protected int zGridSize;
    protected GameObjectBaseType gameObjectBaseType;
    protected CargoContainerLockSystem[,,] containerGrid;
    // public CargoContainerLockSystem[,,] ContainerGrid { get { return containerGrid; } set { containerGrid = value; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjectBaseType = GetComponent<GameObjectBaseType>();
        containerGrid = new CargoContainerLockSystem[xGridSize,yGridSize,zGridSize];
    }
    void OnTriggerEnter(Collider collider)
    {
        CargoContainerManager cargoContainerManager = collider.GetComponent<CargoContainerManager>();
        if(cargoContainerManager)
        {
            collider.transform.SetParent(transform);
            cargoContainerManager.CargoContainerLockSystem.CargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = 
                cargoContainerManager.CargoContainerLockSystem.CargoContainerLockSystemStateManager.CargoContainerSystemLockedState;
        }
    }
}
