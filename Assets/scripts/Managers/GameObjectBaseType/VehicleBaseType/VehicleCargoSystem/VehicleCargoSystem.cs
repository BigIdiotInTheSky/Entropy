using UnityEngine;
using System;

public class VehicleCargoSystem : MonoBehaviour
{
    // private bool containerContact;
    private VehicleTypeBase vehicleManager;
    private Collider containerCollider;
    private VehicleCargoSystemStateManager vehicleCargoSystemStateManager;

    // public bool ContainerContact { get { return containerContact; } }
    public VehicleTypeBase VehicleManager { get { return vehicleManager; } }
    public Collider ContainerCollider { get { return containerCollider; } }
    void Start()
    {
        vehicleManager = GetComponent<VehicleTypeBase>();
        vehicleCargoSystemStateManager = new VehicleCargoSystemStateManager(this);
    }
    void OnTriggerStay(Collider collider)
    {
        // Debug.Log(Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60);
        Rigidbody target = collider.GetComponent<Rigidbody>();
        if (target &&  collider.gameObject.tag == "container")
        {
            // if ((Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60) && 
            //     Math.Round(vehicleManager.Rb.linearVelocity.magnitude, 1) == 0)
            {
                // containerContact = true;
                containerCollider = collider;
                vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState = vehicleCargoSystemStateManager.VehicleCargoSystemLockedState;
            }
            // else { containerContact = false; }
        }
    }
    void FixedUpdate()
    {
        vehicleCargoSystemStateManager.CurrentVehicleCargoSystemState.UpdateState();
    }
}
