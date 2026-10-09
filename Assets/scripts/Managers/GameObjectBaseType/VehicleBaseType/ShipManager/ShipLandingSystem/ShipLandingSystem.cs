using UnityEngine;

public class ShipLandingSystem : MonoBehaviour
{
    private ShipManager shipManager;
    private Animator animator;
    private ShipLandingSystemStateManager shipLandingSystemStateManager;

    public ShipManager ShipManager { get { return shipManager; } }
    public Animator Animator { get { return animator; } }
    public ShipLandingSystemStateManager ShipLandingSystemStateManager { get { return shipLandingSystemStateManager; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        shipManager = GetComponent<ShipManager>();
        shipLandingSystemStateManager = new ShipLandingSystemStateManager(this);
    }

}
