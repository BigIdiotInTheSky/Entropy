using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShipVTOLSystem : MonoBehaviour
{
    private ShipManager shipManager;
    private Animator animator;
    private ShipVTOLSystemStateManager shipVTOLSystemStateManager;
    private float moveActionValue;
    private float localv;
    private Vector3 trans;

    public ShipManager ShipManager { get { return shipManager; } }
    public Animator Animator { get { return animator; } }
    public ShipVTOLSystemStateManager ShipVTOLSystemStateManager { get { return shipVTOLSystemStateManager; } }
    public float MoveActionValue { get { return moveActionValue; } set { moveActionValue = value; } }
    public float LocalV { get { return localv; } set { localv = value; } } 
    public Vector3 Trans { get { return trans; } set { trans = value; } }
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

    }
}
