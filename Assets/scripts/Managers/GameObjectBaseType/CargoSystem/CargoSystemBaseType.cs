using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class CargoSystemBaseType : MonoBehaviour
{
    const int maxGridSize = 100;

    [Header("Cargo Grid")]
    [SerializeField, Range(1,maxGridSize)] private int xGridSize;
    [SerializeField, Range(1,maxGridSize)] private int yGridSize;
    [SerializeField, Range(1,maxGridSize)] private int zGridSize;

    // Offset determines transfrom difference between containers on one cargo grid
    [SerializeField] protected int xGridOffset;
    [SerializeField] protected int yGridOffset;
    [SerializeField] protected int zGridOffset;

    [Header("Load on Start")]
    [SerializeField] private int startingContainers;

    protected GameObjectBaseType gameObjectBaseType;
    protected CargoContainerLockSystem[,,] containerGrid;
    // protected BoxCollider[,,] containerColliders;
    protected Rigidbody rigidbody;
    protected Transform containerMarker;
    protected Vector3 gridOffset;

    public Transform ContainerMarker { get { return containerMarker; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjectBaseType = GetComponent<GameObjectBaseType>();
        rigidbody = GetComponent<Rigidbody>();
        containerGrid = new CargoContainerLockSystem[xGridSize,yGridSize,zGridSize];
        // containerColliders = new BoxCollider[xGridSize,yGridSize,zGridSize];
        gridOffset = Vector3.zero;
        containerMarker = transform.Find("ContainerMarker");
        if (!containerMarker) { throw new System.Exception("ContainerMarker not found"); }
        if (startingContainers != 0) { InitContainers(); }   
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
                        // BoxCollider containerCollider = containerColliders[i,j,k];
                        
                        // Destroy(containerCollider);
                    }
                }
            }
        }
    }
    private void AddContainerToGrid(CargoContainerLockSystem cargoContainerLockSystem)
    {

        for (int i = 0; i < containerGrid.GetLength(0); i++)
        {
            // Debug.Log("i: "+i);
            for (int j = 0; j < containerGrid.GetLength(1); j++)
            {
                // Debug.Log("j: "+j);
                for (int k = 0; k < containerGrid.GetLength(2); k++)
                {
                    // Debug.Log("k: "+k);
                    if (containerGrid[i,j,k] == null)
                    {
                        gridOffset = new Vector3(i*xGridOffset,k*yGridOffset*-1,j*zGridOffset*-1);

                        int[] index = {i,j,k};
                        containerGrid[i,j,k] = cargoContainerLockSystem;
                        cargoContainerLockSystem.CargoSystemBaseType = this;
                        CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager = cargoContainerLockSystem.CargoContainerLockSystemStateManager;
                        cargoContainerLockSystemStateManager.CargoContainerSystemLockedState.ContainerIndex = index;
                        cargoContainerLockSystemStateManager.CargoContainerSystemLockedState.ContainerOffset = gridOffset;
                        cargoContainerLockSystemStateManager.CurrentCargoContainerSystemState = cargoContainerLockSystemStateManager.CargoContainerSystemLockedState;

                        // BoxCollider containerCollider = gameObject.AddComponent<BoxCollider>();
                        // containerCollider.center = cargoContainerLockSystem.transform.localPosition;
                        // containerCollider.size = cargoContainerLockSystem.ContainerCollider.size;
                        // containerColliders[i,j,k] = containerCollider;
                        
                        return;
                    }
                }
            }
        }
        Debug.Log("grid full!");
    }
    private void InitContainers()
    {
        var cargoContainerObject = Resources.Load("cargocontainer");
        if (!cargoContainerObject)
        {
            throw new FileNotFoundException("container prefab not found!");
        }

        for (int i = 0; i < startingContainers; i++)
        {
            GameObject cargoContainer = Instantiate((GameObject)cargoContainerObject, new Vector3(0, 0, 0), Quaternion.identity);
            CargoContainerLockSystem cargoContainerLockSystem = cargoContainer.GetComponent<CargoContainerLockSystem>();
            if (cargoContainerLockSystem) { AddContainerToGrid(cargoContainerLockSystem); }
        }
    }
}
