using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class OnState : SMSBaseState
{
    private StateManager stateManagerX;
    private StateManager stateManagerY;
    private StateManager stateManagerZ;
    private RotationStateManager rotationStateManagerX;
    private RotationStateManager rotationStateManagerY;
    private RotationStateManager rotationStateManagerZ;
    private StateManager vtolStateManager;
    public StateManager VTOLStateManager { get { return vtolStateManager; } }
    public OnState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters, 
        Dictionary<string,List<ThrusterEffectInfo>> vtolThrusters) : base(sMSStateManager, moveThrusters, rotateThrusters, vtolThrusters)
    {
        InitStateManagers();
    }
    public override void UpdateState() 
    {   
        Rigidbody rigidbody = sMSStateManager.ShipMovementSystem.Rigidbody;
        Transform trans = sMSStateManager.ShipMovementSystem.transform;
        Vector3 moveOutput = sMSStateManager.ShipMovementSystem.ShipManager.ShipControlSystem.CurrentControlType.MoveOutput;
        Vector3 rotateOutput = sMSStateManager.ShipMovementSystem.ShipManager.ShipControlSystem.CurrentControlType.RotateOutput;

        Vector3 localV = sMSStateManager.ShipMovementSystem.transform.InverseTransformDirection(rigidbody.linearVelocity);
        stateManagerX.CurrentState.UpdateState(moveOutput.x, (float)Math.Round(localV.x,1), trans.right);
        stateManagerY.CurrentState.UpdateState(moveOutput.y*-1, (float)Math.Round(localV.y,1), trans.up);
        stateManagerZ.CurrentState.UpdateState(moveOutput.z, (float)Math.Round(localV.z,1), trans.forward);

        Vector3 localT = sMSStateManager.ShipMovementSystem.transform.InverseTransformDirection(rigidbody.angularVelocity);
        rotationStateManagerX.CurrentState.UpdateState(rotateOutput.x, (float)Math.Round(localT.x,2), trans.right);
        rotationStateManagerY.CurrentState.UpdateState(rotateOutput.y, (float)Math.Round(localT.y,2), trans.up);
        rotationStateManagerZ.CurrentState.UpdateState(rotateOutput.z, (float)Math.Round(localT.z,2), trans.forward);

        sMSStateManager.ShipMovementSystem.ShipManager.ShipVTOLSystem.UpdateVTOl();

        vtolStateManager.CurrentState.UpdateState(sMSStateManager.ShipMovementSystem.ShipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.CurrentShipVTOLState.MoveActionValue,
            (float)Math.Round(sMSStateManager.ShipMovementSystem.ShipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.CurrentShipVTOLState.LocalV,1), 
            sMSStateManager.ShipMovementSystem.ShipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.CurrentShipVTOLState.Trans);
    }
    public override void EnterState() { ToggleThrusters(true); }

    private void InitStateManagers()
    {
        stateManagerX = new StateManager(true, sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TangentAcclerationForce, 
            sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TangentAcclerationForce, sMSStateManager.ShipMovementSystem.Rigidbody, moveThrusters["rightThrusters"], 
            moveThrusters["leftThrusters"],this);
        stateManagerY = new StateManager(true, sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TangentAcclerationForce, 
            sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TangentAcclerationForce, sMSStateManager.ShipMovementSystem.Rigidbody, moveThrusters["downThrusters"], 
            moveThrusters["upThrusters"], this);
        stateManagerZ = new StateManager(false, sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.ForeAcclerationForce, 
            sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.AftAccelerationForce, sMSStateManager.ShipMovementSystem.Rigidbody, moveThrusters["foreThrusters"], 
            moveThrusters["aftThrusters"], this);

        rotationStateManagerX = new RotationStateManager(sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TorqueForce, sMSStateManager.ShipMovementSystem.Rigidbody, 
            rotateThrusters["pitchNegativeThrusters"],rotateThrusters["pitchPositiveThrusters"],this);
        rotationStateManagerY = new RotationStateManager(sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TorqueForce, sMSStateManager.ShipMovementSystem.Rigidbody, 
            rotateThrusters["yawNegativeThrusters"],rotateThrusters["yawPositiveThrusters"],this);
        rotationStateManagerZ = new RotationStateManager(sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.TorqueForce, sMSStateManager.ShipMovementSystem.Rigidbody, 
            rotateThrusters["rollNegativeThrusters"],rotateThrusters["rollPositiveThrusters"],this);
        
        vtolStateManager = new StateManager(true, sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.PositiveVTOLForce, 
            sMSStateManager.ShipMovementSystem.ShipManager.ShipProfile.NegativeVTOLForce, sMSStateManager.ShipMovementSystem.Rigidbody, 
            vtolThrusters["downThrusters"], vtolThrusters["upThrusters"], this);
    }
    public void ToggleThrusters(bool activeInactive, List<ThrusterEffectInfo> thrusterEffects)
    {
        // Debug.Log(thrusterEffects.Count);
        if (thrusterEffects != null)
        {
            for (int i = 0; i < thrusterEffects.Count; i++)
            {
                thrusterEffects[i].ToggleThrusterActiveInactive(activeInactive);
                // Debug.Log("toggled thruster #"+i+": "+activeInactive);
            }
        }
    }
}
