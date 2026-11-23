using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Controls;

public class CargoContainerSystemLockedState : CargoContainerBaseState
{
    private int[] containerIndex = new int[2];
    private Vector3 containerOffset;

    public CargoContainerSystemLockedState(CargoContainerLockSystemStateManager cargoContainerLockSystemStateManager) : base (cargoContainerLockSystemStateManager) {}
    public int[] ContainerIndex { get { return containerIndex; } set { containerIndex = value; } }
    public Vector3 ContainerOffset { get { return containerOffset; } set {containerOffset = value; } }
    public override void EnterState()
    {
        rigidbody.detectCollisions = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log(cargoContainerLockSystemStateManager.CargoContainerLockSystem.CargoSystemBaseType);
        cargoContainerLockSystemStateManager.CargoContainerLockSystem.transform.SetParent(cargoContainerLockSystemStateManager.CargoContainerLockSystem.CargoSystemBaseType.ContainerMarker);
        UpdateState();
    }

    public override void UpdateState()
    {
        cargoContainerLockSystemStateManager.CargoContainerLockSystem.transform.localPosition = ContainerOffset;
        cargoContainerLockSystemStateManager.CargoContainerLockSystem.transform.localEulerAngles = Vector3.zero;  
    }
}
