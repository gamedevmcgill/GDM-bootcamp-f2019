using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;

    //dampTime
    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    protected AnimatorOverrideController overrideController;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        //allows overriding in animator of specific animation, used here for swappnig attack animations
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = defaultAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    protected virtual void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        //animator gets to the float over the course of time
        //this smoothening is incremented by locomationAnimationSmoothTime over Time.deltaTime
        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);

        animator.SetBool("inCombat", combat.GetInCombat());
    }
    
    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
        int currentIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[currentIndex];
    }
}