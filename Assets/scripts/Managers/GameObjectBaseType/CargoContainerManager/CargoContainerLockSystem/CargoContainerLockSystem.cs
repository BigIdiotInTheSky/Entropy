using UnityEngine;

public class CargoContainerLockSystem : MonoBehaviour
{
    private bool containerContact;
    private CargoContainerManager cargoContainerManager;
    private CargoContainerSystemStateManager cargoContainerSystemStateManager;

    // public bool ContainerContact { get { return containerContact; } }
    public CargoContainerManager CargoContainerManager { get { return cargoContainerManager; } }
    void Start()
    {
        cargoContainerManager = GetComponent<CargoContainerManager>();
        cargoContainerSystemStateManager = new CargoContainerSystemStateManager(this);
    }
    void OnTriggerStay(Collider collider)
    {
        // // Debug.Log(Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60);
        // Rigidbody target = collider.GetComponent<Rigidbody>();
        // if (target &&  collider.gameObject.tag == "container")
        // {
        //     // if ((Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60) && 
        //     //     Math.Round(vehicleManager.Rb.linearVelocity.magnitude, 1) == 0)
        //     {
        //         // containerContact = true;
        //         containerCollider = collider;
        //         vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState = vehicleCargoSystemStateManager.VehicleCargoSystemLockedState;
        //     }
        //     // else { containerContact = false; }
        // }
    }
    void FixedUpdate()
    {
        // vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState.UpdateState();
    }
}
