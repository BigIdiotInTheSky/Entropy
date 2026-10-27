using Unity.VisualScripting;
using UnityEngine;

public class VehicleCargoSystemLockedState : VehicleCargoSystemBaseState
{
    private Rigidbody rigidbody;
    public VehicleCargoSystemLockedState(VehicleCargoSystemStateManager vehicleCargoSystemStateManager) : base (vehicleCargoSystemStateManager) {}

    public override void EnterState()
    {
        rigidbody = vehicleCargoSystemStateManager.VehicleCargoSystem.ContainerCollider.GetComponent<Rigidbody>();
        rigidbody.detectCollisions = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        vehicleCargoSystemStateManager.VehicleCargoSystem.ContainerCollider.transform.SetParent(vehicleCargoSystemStateManager.VehicleCargoSystem.transform);
    }
    public override void UpdateState()
    {
        rigidbody.rotation = vehicleCargoSystemStateManager.VehicleCargoSystem.VehicleManager.Rb.rotation;
    }
}
