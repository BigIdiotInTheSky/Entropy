using UnityEngine;
using System.Collections.Generic;

public class ShipMovementSystem : MonoBehaviour
{
    private SMSStateManager sMSStateManager;
    private ShipManager shipManager;
    private Dictionary<string,List<ThrusterEffectInfo>> moveThrusters;
    private Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters;
    private Dictionary<string, Dictionary<string, List<ThrusterEffectInfo>>> vtolThrusters;
    public ShipManager ShipManager { get { return shipManager; } }
    public SMSStateManager SMSStateManager { get { return sMSStateManager; } }
    public Dictionary<string,List<ThrusterEffectInfo>> RotateThrusters { get { return rotateThrusters; } }
    public Dictionary<string,List<ThrusterEffectInfo>> MoveThrusters { get { return moveThrusters; } }
    public Dictionary<string, Dictionary<string, List<ThrusterEffectInfo>>> VTOLThrusters { get { return vtolThrusters; } }

    private void InitThrusters()
    {
        moveThrusters = new Dictionary<string, List<ThrusterEffectInfo>>
        {
            { "upThrusters", new List<ThrusterEffectInfo>() },
            { "downThrusters", new List<ThrusterEffectInfo>() },
            { "leftThrusters", new List<ThrusterEffectInfo>() },
            { "rightThrusters", new List<ThrusterEffectInfo>() },
            { "foreThrusters", new List<ThrusterEffectInfo>() },
            { "aftThrusters", new List<ThrusterEffectInfo>() }
        };
        rotateThrusters = new Dictionary<string,List<ThrusterEffectInfo>>
        {
            { "pitchPositiveThrusters", new List<ThrusterEffectInfo>() },
            { "pitchNegativeThrusters", new List<ThrusterEffectInfo>() },
            { "yawPositiveThrusters", new List<ThrusterEffectInfo>() },
            { "yawNegativeThrusters", new List<ThrusterEffectInfo>() },
            { "rollPositiveThrusters", new List<ThrusterEffectInfo>() },
            { "rollNegativeThrusters", new List<ThrusterEffectInfo>() }
        };
        vtolThrusters = new Dictionary<string, Dictionary<string, List<ThrusterEffectInfo>>>
        {
            { "downPos", new Dictionary<string, List<ThrusterEffectInfo>>
                {
                    { "upThrusters", new List<ThrusterEffectInfo>() },
                    { "downThrusters", new List<ThrusterEffectInfo>() },
                }
            },
            { "upPos", new Dictionary<string, List<ThrusterEffectInfo>>
                {
                    { "foreThrusters", new List<ThrusterEffectInfo>() },
                    { "aftThrusters", new List<ThrusterEffectInfo>() }
                }
            }
        };
    }

    void Awake()
    {
        InitThrusters();
        shipManager = GetComponent<ShipManager>();  
        sMSStateManager = new SMSStateManager(this);
    }
    
    void FixedUpdate()
    {
        sMSStateManager.CurrentState.UpdateState();
    }
}
