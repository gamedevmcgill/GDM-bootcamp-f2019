using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    const float combatCooldown = 5f;
    private float lastAttackTime;

    public float attackDelay = 0.6f;

    private bool inCombat = false;
    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats opponentStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if(Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }
    }

    public bool GetInCombat()
    {
        return inCombat;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0)
        {
            opponentStats = targetStats;
            if(OnAttack != null)
            {
                OnAttack();
            }
            //also seen as OnAttack?.Invoke(); where ? checks if null

            attackCooldown = 1f / attackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    public void AttackHit_AnimationEvent()
    {
        opponentStats.TakeDamage(myStats.damage.GetValue());
        //if kill target, immediately change to not in combat
        if (opponentStats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }
}
