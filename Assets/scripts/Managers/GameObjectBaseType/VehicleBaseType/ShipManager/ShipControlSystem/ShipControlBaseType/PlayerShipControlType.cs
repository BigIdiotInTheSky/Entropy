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
    [SerializeField] private InputActionReference toggleGear;
    private ShipControlSystem shipControlSystem;
    void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();
        toggleThrust.action.Enable();
        toggleVTOL.action.Enable();
        toggleGear.action.Enable();
    }
    void OnDisable()
    {
        move.action.Disable();
        rotate.action.Disable();
        toggleThrust.action.Disable();
        toggleVTOL.action.Disable();
        toggleGear.action.Disable();
    }
    void Start()
    {
        toggleThrust.action.performed += ToggleThrustPerformed;
        toggleVTOL.action.performed += ToggleVTOLPerformed;
        toggleGear.action.performed += ToggleGearPerformed;
        
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
    void ToggleGearPerformed(InputAction.CallbackContext context)
    {
        shipControlSystem.ShipManager.ShipLandingSystem.ShipLandingSystemStateManager.ToggleGearUpDown();
    }
}
