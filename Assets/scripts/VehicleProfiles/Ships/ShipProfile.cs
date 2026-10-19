using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "VehicleProfile", menuName = "Scriptable Objects/VehicleProfile/ShipProfile")]
public class ShipProfile : VehicleProfile
{
    // [Header("Ship Class")] 
    // [SerializeField] private ShipClass shipClass;

    [Header("Maximum Forces")]
    [SerializeField] private float maxLinearVelocity;
    [SerializeField] private float maxAngularVelocity;

    [Header("Acceleration Forces")]
    [SerializeField] private float foreAcclerationForce;
    [SerializeField] private float aftAccelerationForce;
    [SerializeField] private float tangentAcclerationForce;

    [Header("Torque Force")]
    [SerializeField] private float torqueForce;

    [Header("VTOL Force")]
    [SerializeField] private float positiveVTOLForce;
    [SerializeField] private float negativeVTOLForce;

    // private enum ShipClass
    // {
    //     SmallCraft,
    //     Corvette,
    //     Frigate,
    //     Destroyer,
    //     Capital
    // }

    // public ShipClass ShipClass { get { return shipClass; } }
    public float MaxAngularVelocity { get { return maxAngularVelocity; } }
    public float MaxLinearVelocity { get { return maxLinearVelocity; } }
    public float ForeAcclerationForce { get { return foreAcclerationForce; } }
    public float AftAccelerationForce { get { return aftAccelerationForce; } }
    public float TangentAcclerationForce { get { return tangentAcclerationForce; } }
    public float TorqueForce { get { return torqueForce; } }
    public float PositiveVTOLForce { get { return positiveVTOLForce; } }
    public float NegativeVTOLForce { get { return negativeVTOLForce; } }
}
