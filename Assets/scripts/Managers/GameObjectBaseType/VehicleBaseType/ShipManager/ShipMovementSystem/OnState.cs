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
    private ShipManager shipManager;

    public StateManager VTOLStateManager { get { return vtolStateManager; } }
    public OnState(SMSStateManager sMSStateManager, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters, Dictionary<string,List<ThrusterEffectInfo>> rotateThrusters, 
        Dictionary<string,List<ThrusterEffectInfo>> vtolThrusters, ShipManager shipManager) : base(sMSStateManager, moveThrusters, rotateThrusters, vtolThrusters)
    {
        this.shipManager = shipManager;
        initStateManagers();
    }
    public override void UpdateState() 
    {   
        Rigidbody rb = shipManager.Rb;
        Transform trans = shipManager.Trans;
        Vector3 moveOutput = shipManager.ShipControlSystem.CurrentControlType.MoveOutput;
        Vector3 rotateOutput = shipManager.ShipControlSystem.CurrentControlType.RotateOutput;

        Vector3 localV = shipManager.Trans.InverseTransformDirection(rb.linearVelocity);
        stateManagerX.CurrentState.UpdateState(moveOutput.x, (float)Math.Round(localV.x,1), trans.right);
        stateManagerY.CurrentState.UpdateState(moveOutput.y*-1, (float)Math.Round(localV.y,1), trans.up);
        stateManagerZ.CurrentState.UpdateState(moveOutput.z, (float)Math.Round(localV.z,1), trans.forward);

        Vector3 localT = shipManager.Trans.InverseTransformDirection(rb.angularVelocity);
        rotationStateManagerX.CurrentState.UpdateState(rotateOutput.x, (float)Math.Round(localT.x,2), trans.right);
        rotationStateManagerY.CurrentState.UpdateState(rotateOutput.y, (float)Math.Round(localT.y,2), trans.up);
        rotationStateManagerZ.CurrentState.UpdateState(rotateOutput.z, (float)Math.Round(localT.z,2), trans.forward);

        vtolStateManager.CurrentState.UpdateState(shipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.CurrentShipVTOLState.MoveActionValue,
            shipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.CurrentShipVTOLState.LocalV, shipManager.ShipVTOLSystem.ShipVTOLSystemStateManager.CurrentShipVTOLState.Trans);
    }
    public override void EnterState() { ToggleMoveThrusters(true); }

    private void initStateManagers()
    {
        stateManagerX = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce, 
            shipManager.Rb, moveThrusters["rightThrusters"], moveThrusters["leftThrusters"],this);
        stateManagerY = new StateManager(true, shipManager.ShipProfile.TangentAcclerationForce, shipManager.ShipProfile.TangentAcclerationForce,
            shipManager.Rb, moveThrusters["downThrusters"], moveThrusters["upThrusters"], this);
        stateManagerZ = new StateManager(false, shipManager.ShipProfile.ForeAcclerationForce, shipManager.ShipProfile.AftAccelerationForce,
            shipManager.Rb, moveThrusters["foreThrusters"], moveThrusters["aftThrusters"], this);

        rotationStateManagerX = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, 
            rotateThrusters["pitchNegativeThrusters"],rotateThrusters["pitchPositiveThrusters"],this);
        rotationStateManagerY = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, 
            rotateThrusters["yawNegativeThrusters"],rotateThrusters["yawPositiveThrusters"],this);
        rotationStateManagerZ = new RotationStateManager(shipManager.ShipProfile.TorqueForce, shipManager.Rb, 
            rotateThrusters["rollNegativeThrusters"],rotateThrusters["rollPositiveThrusters"],this);
        
        vtolStateManager = new StateManager(false, shipManager.ShipProfile.PositiveVTOLForce, shipManager.ShipProfile.PositiveVTOLForce, shipManager.Rb, 
            vtolThrusters["foreThrusters"], vtolThrusters["aftThrusters"], this);
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
