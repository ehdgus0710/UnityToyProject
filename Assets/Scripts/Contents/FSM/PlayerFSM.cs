using UnityEngine;

public class PlayerFSM : FSMController<PlayerStateType>
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private Animator animator;
    public Animator Animator {  get { return animator; } }

    private bool isGrounded = false;
    private bool isRespwan = true;
    private bool isMoveable = true;

    private float currentIdleTime = 0f;

    [SerializeField]
    private float timeoutToIdleTime = 5f;
    private bool isTimeoutToIdle = false;
    //private bool isJump

    protected void Awake()
    {
    }

    protected virtual void Start()
    {


        ChangeState(PlayerStateType.Idle);
    }

    protected override void Update()
    {
        base.Update();

        //if(!isMove && isRespwan && !isTimeoutToIdle)
        //{
        //    isTimeoutToIdle = true;
        //    currentIdleTime += Time.deltaTime;

        //    if (currentIdleTime >= timeoutToIdleTime)
        //        animator.SetTrigger(PlayerUtilAnimation.hashTimeoutToIdle);
        //}
    }


    public void AttackInput()
    {
    }

    private void OnEnable()
    {
    }

    public void OnInputMouseRightButton()
    {
        if (!isMoveable && currentStateType == PlayerStateType.Dash)
            return;

        ChangeState(PlayerStateType.Move);

        Vector3 mousePoint;
    }

    public void OnDashInput()
    {
        if (!isMoveable && currentStateType == PlayerStateType.Dash)
            return;

        ChangeState(PlayerStateType.Dash);
    }

    public void OnAttackInput()
    {
        if (!isMoveable && currentStateType == PlayerStateType.Dash)
            return;
    }

    public void Respawn()
    {
        animator.SetTrigger(PlayerUtilAnimation.hashRespawn);
    }

    public void RespawnFinished()
    {
        isRespwan = false;
        //damageable.isInvulnerable = false;
    }

    public void SetMoveable(bool isMoveable)
    {
        this.isMoveable = isMoveable;
    }

    public override void FindAndAddState(PlayerStateType findStateType)
    {
        System.Type stateType = PlayerTypeInfo.GetPlayerStateType(findStateType);
        var state = (BaseState<PlayerStateType>)gameObject.GetComponentInChildren(stateType);

        if (state != null)
            stateTable.Add(findStateType, state);
    }
    public override void FindAndAddAllStates()
    {
        stateTable.Clear();

        for (int i = (int)PlayerStateType.Idle; i < (int)PlayerStateType.End; i++)
        {
            FindAndAddState((PlayerStateType)i);
        }
    }

    public override void AddAllStates()
    {
        for (int i = (int)PlayerStateType.Idle; i < (int)PlayerStateType.End; i++)
        {
            System.Type stateType = PlayerTypeInfo.GetPlayerStateType((PlayerStateType)i);
            BaseState<PlayerStateType> state = (BaseState<PlayerStateType>)gameObject.AddComponent(stateType);
            
            if (state != null)
                stateTable.Add((PlayerStateType)i, state);
        }
    }

}

