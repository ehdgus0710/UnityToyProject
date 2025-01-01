using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : BaseState<PlayerStateType>
{
    protected PlayerFSM playerFSM;
    public PlayerFSM PlayerFSM { get { return playerFSM; } }

    protected virtual void Awake()
    {
        playerFSM = GetComponent<PlayerFSM>();
    }
    public override void Enter()
    {
        enterStateEvent?.Invoke();
        this.enabled = true;
    }
    public override void ExcuteUpdate()
    {
        excuteUpdateStateEvent?.Invoke();
    }
    public override void ExcuteFixedUpdate()
    {
        excuteFixedUpdateStateEvent?.Invoke();
    }

    public override void Exit()
    {
        exitStateEvent?.Invoke();
        this.enabled = false;
    }
}
