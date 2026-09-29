using UnityEngine;
using System.Collections.Generic;
using Mono.Cecil.Cil;

public abstract class BaseState
{
    protected StateManager stateManager;
    protected bool dampen;
    protected List<ThrusterEffectInfo> moveThrusters;
    private OnState smsOnState;

    public bool Dampen { get { return dampen; } set { dampen = value; } }
    public List<ThrusterEffectInfo> MoveThrusters { get { return moveThrusters; } set { moveThrusters = value; } }
    protected BaseState(StateManager stateManager, bool dampen, List<ThrusterEffectInfo> moveThrusters, OnState smsOnState)
    {
        this.smsOnState = smsOnState;
        this.stateManager = stateManager;
        this.dampen = dampen;
        this.moveThrusters = moveThrusters;
    }
    public abstract void UpdateState(float moveActionValue, float localV, Vector3 trans);
    public abstract void EnterState();
    public abstract void ExitState();
    protected void Accelerate(float moveActionValue, Vector3 trans, Rigidbody rb, float accelerationForce)
    {
        rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce * moveActionValue*-1, ForceMode.Force);
    }
    protected void ToggleThrusters(bool toggleThrusters)
    {
        smsOnState.ToggleThrusters(toggleThrusters, moveThrusters);
    }
}
