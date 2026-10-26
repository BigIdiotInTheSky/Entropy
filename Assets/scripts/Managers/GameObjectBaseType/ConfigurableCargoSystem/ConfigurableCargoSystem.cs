using UnityEngine;

public class VehicleCargoSystem : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void OnTriggerStay(Collider collider)
    {
        // Debug.Log(Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60);
        Rigidbody target = collider.GetComponent<Rigidbody>();
        if (target &&  collider.gameObject.tag == "container") {
            if ((Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60) /* && 
                Math.Round(vehicleManager.Rb.linearVelocity.magnitude) - Math.Round(target.linearVelocity.magnitude) == 0 */)
            {
                Debug.Log("Container locked");
            }
        }
    }
}