using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShipVTOLSystem : MonoBehaviour
{
    private Animator animator;
    private ShipVTOLSystemStateManager shipVTOLSystemStateManager;
    
    public ShipVTOLSystemStateManager ShipVTOLSystemStateManager { get { return shipVTOLSystemStateManager; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        shipVTOLSystemStateManager = new ShipVTOLSystemStateManager(animator);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
