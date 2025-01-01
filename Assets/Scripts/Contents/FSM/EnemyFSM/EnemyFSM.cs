using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : FSMController<EnemyStateType>
{
    [SerializeField]
    protected EnemyProfile enemyProfile;
    public EnemyProfile EnemyProfile { get { return enemyProfile; } }

    [SerializeField]
    protected EntityStatus enemyStatus;
    public EntityStatus EntityStatus { get { return enemyStatus; } }

    [SerializeField]
    protected Animator animator;
    public Animator Animator { get { return animator; } }

    //private EnemyController enemyController;
    //public EnemyController EnemyController { get { return enemyController; } }

    private bool isCanAttack = false;
    public bool IsCanAttack { get { return isCanAttack; } }

    public void SetAttackEnd()
    {
        isCanAttack = false;
        currentAttackWaitTime = EntityStatus.CurrentStatusTypeValue(StatusInfoType.AttackSpeed);
    }

    private float currentAttackWaitTime;

    protected virtual void Start()
    {
        //EntityStatus.deathEvent.AddListener(OnEnemyDeath);
    }

    public override void AddAllStates()
    {
        var states = GetComponents<EnemyBaseState>();
        StateTable.Clear();

        foreach (var state in states)
        {
            AddState(state.StateType, state);
        }
    }

    //public void SetEnemyController(EnemyController enemyController)
    //{
    //    this.enemyController = enemyController;
    //}

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    //public float GetTargetDistance()
    //{
    //    return Vector3.Distance(transform.position, EnemyController.GetPlayerPosition());
    //}

    //public Vector3 GetTargetDirection()
    //{
    //    return -(transform.position - EnemyController.GetPlayerPosition()).normalized;
    //}

    //private void OnEnemyDeath()
    //{
    //    gameObject.layer = GetLayer.EnemyDeath;
    //    enemyController.RemoveEnmey(this);
    //    ChangeState(EnemyStateType.Death);
    //}


    // [SerializeField]
    // protected EnemyProfile enemyProfile;
    // public EnemyProfile EnemyProfile { get { return enemyProfile; } }

    // [SerializeField]
    // protected Transform attackPoint;
    // public Transform AttackPoint { get { return attackPoint; } }

    //[SerializeField]
    // protected EntityStatus enemyStatus;
    // public EntityStatus EntityStatus { get { return enemyStatus; } }

    // [SerializeField]
    // protected Animator animator;
    // public Animator Animator { get { return animator; } }

    // //[SerializeField]
    // //protected EnemyAnimatorParameterContainer animatorParameterContainer;
    // //public EnemyAnimatorParameterContainer AnimatorParameterContainer { get { return animatorParameterContainer; } }
    // //public int GetTriggerID(EnemyAnimationClipType clipType)
    // //{
    // //    return animatorParameterContainer.GetTriggerID(clipType);
    // //}
    public float currentStatusTypeValue(StatusInfoType statusInfoType)
    {
        return enemyStatus.CurrentStatusTypeValue(statusInfoType);
    }

    protected void IsCanAttackCheck()
    {
        if (!isCanAttack)
        {
            currentAttackWaitTime -= Time.fixedDeltaTime;

            isCanAttack = currentAttackWaitTime <= 0 ? true : false;
        }
    }

    // protected override void Start()
    // {
    //     base.Start();

    //     //for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; ++i)
    //     //{
    //     //    AnimationClip clip = animator.runtimeAnimatorController.animationClips[i];

    //     //    AnimationEvent animationStartEvent = new AnimationEvent();
    //     //    animationStartEvent.time = 0;
    //     //    animationStartEvent.functionName = "";
    //     //    //animationStartEvent.stringParameter = clip.name;
    //     //    //animationStartEvent.objectReferenceParameter = this.gameObject;

    //     //    AnimationEvent animationEndEvent = new AnimationEvent();
    //     //    animationEndEvent.time = clip.length;
    //     //    animationEndEvent.functionName = "";
    //     //    //animationEndEvent.stringParameter = clip.name;
    //     //    //animationEndEvent.objectReferenceParameter = this.gameObject;

    //     //    clip.AddEvent(animationStartEvent);
    //     //    clip.AddEvent(animationEndEvent);
    //     //}
    //     //var clips = animator.GetCurrentAnimatorClipInfo(0);

    //     //int clipCount = clips.Length;

    //     //foreach (var cl in clips)
    //     //{
    //     //    string name = cl.clip.name;
    //     //    AnimationEvent animationEvent = null;
    //     //    animationEvent.
    //     //}

    //     //animator.runtimeAnimatorController.animationClips.Length
    //     //animator = GetComponent<Animator>();

    //     //ChangeState(enemyProfile.StartState);

    //     //animator.SetTrigger("Create");
    // }

    // public void playAnimation(EnemyAnimationClipType enemyAnimationClipType)
    // {
    //     //animator.Play(GetTriggerID(enemyAnimationClipType));

    //     //.Play()
    // }
}
