using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Animations;

public class VehicleCargoSystem : MonoBehaviour
{
    private VehicleTypeBase vehicleManager;
    void Start()
    {
        vehicleManager = GetComponent<VehicleTypeBase>();
    }
    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log(Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60);
        Rigidbody target = collider.GetComponent<Rigidbody>();
        if (target &&  collider.gameObject.tag == "container")
        {
            
        }
    }
}
