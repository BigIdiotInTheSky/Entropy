using UnityEngine;
using UnityEditor;
public class ShipLandingSystem : MonoBehaviour
{
    private ShipManager shipManager;
    private Animator animator;
    private ShipLandingSystemStateManager shipLandingSystemStateManager;
    private Collider gearCollider;

    public ShipManager ShipManager { get { return shipManager; } }
    public Animator Animator { get { return animator; } }
    public ShipLandingSystemStateManager ShipLandingSystemStateManager { get { return shipLandingSystemStateManager; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        shipManager = GetComponent<ShipManager>();
        gearCollider = GetComponent<BoxCollider>();
        shipLandingSystemStateManager = new ShipLandingSystemStateManager(this);
        SetPose();
    }
    private void SetPose()
    {
        AnimationClip[] animationClips = AnimationUtility.GetAnimationClips(gameObject);
        AnimationClip gearDownClip = GetClip(animationClips, "GearDown");
        AnimationClip idleClip = GetClip(animationClips, "Scene");
        AnimationUtility.SetAdditiveReferencePose(idleClip, gearDownClip, 0);

        AnimationClip gearUpClip = GetClip(animationClips, "GearUp");
        AnimationUtility.SetAdditiveReferencePose(gearUpClip, gearDownClip, 0);

        AnimationUtility.SetAdditiveReferencePose(gearDownClip, gearDownClip, 0);
    }

    private AnimationClip GetClip(AnimationClip[] animationClips, string name)
    {
        for (int i = 0; i < animationClips.Length; i++)
        {
            AnimationClip currentClip = animationClips[i];
            if (currentClip.name.Contains(name)) { return currentClip; }
            // Debug.Log(currentClip.name+" "+name);             
        }
        throw new System.Exception("Not found");
    }
}
            // Debug.Log(currentClip.name+" "+name);  