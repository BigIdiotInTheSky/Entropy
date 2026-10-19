using UnityEngine;
using UnityEditor;
using UnityEngine.Animations;
public class ShipLandingSystem : MonoBehaviour
{
    private Animator animator;
    private ShipLandingSystemStateManager shipLandingSystemStateManager;
    private bool padContact;
    private ShipManager shipManager;
    private Collider collider;
    private PositionConstraint positionConstraint;

    public Animator Animator { get { return animator; } }
    public bool PadContact { get { return padContact; } }
    public ShipLandingSystemStateManager ShipLandingSystemStateManager { get { return shipLandingSystemStateManager; } }
    public ShipManager ShipManager { get { return shipManager; } }
    public Collider Collider { get { return collider; } }
    public PositionConstraint PositionConstraint { get { return positionConstraint; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shipManager = GetComponent<ShipManager>();
        animator = GetComponent<Animator>();
        positionConstraint = GetComponent<PositionConstraint>();
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
    void OnTriggerStay(Collider collider)
    {

        if ((Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) < 120 || Quaternion.Angle(collider.transform.rotation, gameObject.transform.rotation) > 60) && 
            collider.gameObject.tag == "pad marker")
        {
            padContact = true;
            this.collider = collider;
            Debug.Log("(L) to lock");
        }
        else { padContact = false; }
    }
}
            // Debug.Log(currentClip.name+" "+name);  p