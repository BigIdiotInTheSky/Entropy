using System.Diagnostics;
using UnityEngine;

public class VehicleCargoSystem : MonoBehaviour
{
    [Header("Cargo Grid")]
    [SerializeField, Range(1,100)] private int xGridSize;
    [SerializeField, Range(1,100)] private int yGridSize;
    [SerializeField, Range(1,100)] private int zGridSize;
    private GameObjectBaseType gameObjectBaseType;
    private CargoContainerManager[,,] containerGrid;
    private Rigidbody rigidbody;
    private Transform containerMarker;
    // public CargoContainerLockSystem[,,] ContainerGrid { get { return containerGrid; } set { containerGrid = value; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gameObjectBaseType = GetComponent<GameObjectBaseType>();
        rigidbody = GetComponent<Rigidbody>();
        containerGrid = new CargoContainerManager[xGridSize,yGridSize,zGridSize];
        containerMarker = transform.Find("ContainerMarker");
        if (!containerMarker) { throw new System.Exception("ContainerMarker not found"); }   
    }
    void FixedUpdate()
    {
        for (int i = 0; i < containerGrid.GetLength(0); i++)
        {
            for (int j = 0; j < containerGrid.GetLength(1); j++)
            {
                for (int k = 0; k < containerGrid.GetLength(2); k++)
                {
                    if (containerGrid[i,k,j])
                    {
                        Transform transform = containerGrid[i,k,j].transform;
                        
                        transform.localPosition = Vector3.zero;
                        transform.rotation = containerMarker.rotation;   
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        CargoContainerManager cargoContainerManager = collider.GetComponent<CargoContainerManager>();
        if(cargoContainerManager)
        {
            // collider.transform.SetParent(transform);
            cargoContainerManager.CargoContainerLockSystem.CargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = 
                cargoContainerManager.CargoContainerLockSystem.CargoContainerLockSystemStateManager.CargoContainerSystemLockedState;
            cargoContainerManager.transform.SetParent(containerMarker);
            for (int i = 0; i < containerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < containerGrid.GetLength(1); j++)
                {
                    for (int k = 0; k < containerGrid.GetLength(2); k++)
                    {
                        if (!containerGrid[i,k,j])
                        {
                            containerGrid[i,k,j] = cargoContainerManager;
                            UnityEngine.Debug.Log("Container added to grid!");
                        }
                    }
                }
            }
        }
    }
}
