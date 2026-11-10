using UnityEngine;

public class VehicleCargoSystem : MonoBehaviour
{
    [Header("Cargo Grid")]
    [SerializeField,Range(1,100)] private int xGridLength;
    [SerializeField,Range(1,100)] private int yGridLength;
    [SerializeField,Range(1,100)] private int zGridLength;
    
    private bool containerContact;
    private VehicleTypeBase vehicleManager;
    private Collider containerCollider;
    // private VehicleCargoSystemStateManager vehicleCargoSystemStateManager;

    // public bool ContainerContact { get { return containerContact; } }
    public int XGridLength { get { return xGridLength; } }
    public int YGridLength { get { return yGridLength; } }
    public int ZGridLength { get { return zGridLength; } }
    public VehicleTypeBase VehicleManager { get { return vehicleManager; } }
    public Collider ContainerCollider { get { return containerCollider; } }
    void Start()
    {
        vehicleManager = GetComponent<VehicleTypeBase>();
        // vehicleCargoSystemStateManager = new VehicleCargoSystemStateManager(this);
    }
    void OnTriggerStay(Collider collider)
    {
        // Debug.Log(Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60);
        Rigidbody target = collider.GetComponent<Rigidbody>();
        if (target &&  collider.gameObject.tag == "container")
        {
            CargoContainerLockSystem cargoContainerLockSystem = collider.gameObject.GetComponent<CargoContainerLockSystem>();
            // if ((Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60) && 
            //     Math.Round(vehicleManager.Rb.linearVelocity.magnitude, 1) == 0)
            {
                // containerContact = true;
                containerCollider = collider;
                // vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState = vehicleCargoSystemStateManager.VehicleCargoSystemLockedState;
            }
            // else { containerContact = false; }
        }
    }
    void FixedUpdate()
    {
        // vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState.UpdateState();
    }
}
