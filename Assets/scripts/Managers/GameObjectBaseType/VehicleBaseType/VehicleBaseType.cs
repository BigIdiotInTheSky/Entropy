using System;
using UnityEngine;

public abstract class VehicleBaseType : GameObjectBaseType
{
    private VehicleCargoSystem vehicleCargoSystem;

    public VehicleCargoSystem VehicleCargoSystem { get { return vehicleCargoSystem; } }

    void Start()
    {
        vehicleCargoSystem = GetComponent<VehicleCargoSystem>();
    }
}
