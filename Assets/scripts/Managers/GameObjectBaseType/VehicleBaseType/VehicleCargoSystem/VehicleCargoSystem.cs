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
        // transform.Find();
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
                        Rigidbody rigidbody = containerGrid[i,k,j].GetComponent<Rigidbody>();
                        rigidbody.MoveRotation(Quaternion.Euler(this.rigidbody.rotation.eulerAngles.x, this.rigidbody.rotation.eulerAngles.y, this.rigidbody.rotation.eulerAngles.z));   
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
            collider.transform.SetParent(transform);
            cargoContainerManager.CargoContainerLockSystem.CargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = 
                cargoContainerManager.CargoContainerLockSystem.CargoContainerLockSystemStateManager.CargoContainerSystemLockedState;
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
