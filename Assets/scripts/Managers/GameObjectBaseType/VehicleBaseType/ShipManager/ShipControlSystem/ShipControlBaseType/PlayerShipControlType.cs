using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerShipControlType : ShipControlBaseType
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;
    [SerializeField] private InputActionReference toggleThrust;
    [SerializeField] private InputActionReference toggleVTOL;
    private ShipControlSystem shipControlSystem;
    private void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();
        toggleThrust.action.Enable();
        toggleVTOL.action.Enable();
    }
    private void OnDisable()
    {
        move.action.Disable();
        rotate.action.Disable();
        toggleThrust.action.Disable();
        toggleVTOL.action.Disable();
    }
    void Start()
    {
        toggleThrust.action.performed += ToggleThrustPerformed;
        toggleVTOL.action.performed += ToggleVTOLPerformed;
        
        shipControlSystem = GetComponent<ShipControlSystem>();
    }
    void Update()
    {
        moveOutput = move.action.ReadValue<Vector3>();
        rotateOutput = rotate.action.ReadValue<Vector3>();
    }
    void ToggleThrustPerformed(InputAction.CallbackContext context)
    {
        shipControlSystem.ShipManager.ShipMovementSystem.SMSStateManager.ToggleOnOff();
    }
    void ToggleVTOLPerformed(InputAction.CallbackContext context)
    {
        shipControlSystem.ShipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.ToggleVTOLUpDown();
    }
}
