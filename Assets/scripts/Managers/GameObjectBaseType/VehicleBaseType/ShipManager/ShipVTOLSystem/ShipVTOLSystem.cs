using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShipVTOLSystem : MonoBehaviour
{
    private ShipManager shipManager;
    private Animator animator;
    private ShipVTOLSystemStateManager shipVTOLSystemStateManager;

    public ShipManager ShipManager { get { return shipManager; } }
    public Animator Animator { get { return animator; } }
    public ShipVTOLSystemStateManager ShipVTOLSystemStateManager { get { return shipVTOLSystemStateManager; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        shipManager = GetComponent<ShipManager>();
        shipVTOLSystemStateManager = new ShipVTOLSystemStateManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localV = shipManager.Trans.InverseTransformDirection(shipManager.Rb.linearVelocity);
        shipVTOLSystemStateManager.CurrentShipVTOLState.UpdateState(localV);
    }
}
