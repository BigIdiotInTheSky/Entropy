using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class CargoSystemBaseType : MonoBehaviour
{
    const int maxGridSize = 100;
    [SerializeField] private GameObject cargoContainerPrefab;

    [Header("Cargo Grid")]
    [SerializeField, Range(1,maxGridSize)] private int xGridSize;
    [SerializeField, Range(1,maxGridSize)] private int yGridSize;
    [SerializeField, Range(1,maxGridSize)] private int zGridSize;

    [Header("Load on Start")]
    [SerializeField] private List<GameObject> startingContainers;

    protected GameObjectBaseType gameObjectBaseType;
    protected CargoContainerLockSystem[,,] containerGrid;
    protected BoxCollider[,,] containerColliders;
    protected Rigidbody rigidbody;
    protected Transform containerMarker;

    public Transform ContainerMarker { get { return containerMarker; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjectBaseType = GetComponent<GameObjectBaseType>();
        rigidbody = GetComponent<Rigidbody>();
        containerGrid = new CargoContainerLockSystem[xGridSize,yGridSize,zGridSize];
        containerColliders = new BoxCollider[xGridSize,yGridSize,zGridSize];
        containerMarker = transform.Find("ContainerMarker");
        if (!containerMarker) { throw new System.Exception("ContainerMarker not found"); }
        if (startingContainers != null) { InitContainers(); }   
    }
    void OnTriggerEnter(Collider collider)
    {
        CargoContainerLockSystem cargoContainerLockSystem = collider.GetComponent<CargoContainerLockSystem>();
        Debug.Log(cargoContainerLockSystem);
        if(cargoContainerLockSystem)
        {
           AddContainerToGrid(cargoContainerLockSystem);
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
                    CargoContainerLockSystem cargoContainerLockSystem = containerGrid[i,j,k];
                    if (cargoContainerLockSystem)
                    {
                        CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager = cargoContainerLockSystem.CargoContainerLockSystemStateManager;
                        cargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = cargoContainerLockSystemStateManager.CargoContainerSystemUnlockedState;
                        cargoContainerLockSystem.CargoContainerLockSystemStateManager.JettisonCargo();
                        containerGrid[i,j,k] = null;
                        BoxCollider containerCollider = containerColliders[i,j,k];
                        Destroy(containerCollider);
                    }
                }
            }
        }
    }
    private void AddContainerToGrid(CargoContainerLockSystem cargoContainerLockSystem)
    {
        for (int i = 0; i < containerGrid.GetLength(0); i++)
        {
            for (int j = 0; j < containerGrid.GetLength(1); j++)
            {
                for (int k = 0; k < containerGrid.GetLength(2); k++)
                {
                    if (containerGrid[i,k,j] == null)
                    {
                        int[] index = {i,j,k};
                        containerGrid[i,j,k] = cargoContainerLockSystem;
                        cargoContainerLockSystem.CargoSystemBaseType = this;
                        CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager = cargoContainerLockSystem.CargoContainerLockSystemStateManager;
                        cargoContainerLockSystemStateManager.CargoContainerSystemLockedState.ContainerIndex = index;
                        cargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = cargoContainerLockSystemStateManager.CargoContainerSystemLockedState;
                        BoxCollider containerCollider = gameObject.AddComponent<BoxCollider>();
                        containerCollider.center = containerMarker.localPosition;

                        containerCollider.size = new Vector3(cargoContainerLockSystem.ContainerCollider.size.z, cargoContainerLockSystem.ContainerCollider.size.y, cargoContainerLockSystem.ContainerCollider.size.x);
                        Debug.Log(cargoContainerLockSystem.ContainerCollider.size);
                        containerColliders[i,j,k] = containerCollider;
                        return;
                    }
                }
            }
        }
        Debug.Log("grid full!");
    }
    private void InitContainers()
    {
        for (int i = 0; i < startingContainers.Count; i++)
        {
            GameObject cargoContainer;
            if (startingContainers[i] == null)
            {
                cargoContainer = Instantiate(cargoContainerPrefab, containerMarker.localPosition, containerMarker.rotation);
            }
            else
            {
                cargoContainer = startingContainers[i];
            }
            CargoContainerLockSystem cargoContainerLockSystem = cargoContainer.GetComponent<CargoContainerLockSystem>();
            if (cargoContainerLockSystem) { AddContainerToGrid(cargoContainerLockSystem); }

        }
    }
}
