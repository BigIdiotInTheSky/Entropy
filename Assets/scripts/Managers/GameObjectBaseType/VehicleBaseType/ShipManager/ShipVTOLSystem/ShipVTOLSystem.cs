using UnityEngine;
using UnityEditor;
using System.Threading;

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
        SetPose();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(shipVTOLSystemStateManager.CurrentShipVTOLState);
        Vector3 localV = shipManager.Trans.InverseTransformDirection(shipManager.Rb.linearVelocity);
        shipVTOLSystemStateManager.CurrentShipVTOLState.UpdateState(localV);
    }

    private void SetPose()
    {
        AnimationClip[] animationClips = AnimationUtility.GetAnimationClips(gameObject);
        AnimationClip refClip = GetClip(animationClips, "VTOLUp");
        AnimationClip vtolDownClip = GetClip(animationClips, "VTOLDown");
        AnimationUtility.SetAdditiveReferencePose(vtolDownClip, refClip, 0);
    }

    private AnimationClip GetClip(AnimationClip[] animationClips, string name)
    {
        for (int i = 0; i < animationClips.Length; i++)
        {
            AnimationClip currentClip = animationClips[i];
            if (currentClip.name.Contains(name)) { return currentClip; }
            Debug.Log(currentClip.name+" "+name);             
        }
        throw new System.Exception("Not found");
    }
}

