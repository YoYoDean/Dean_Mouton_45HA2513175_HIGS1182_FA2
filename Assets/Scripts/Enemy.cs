using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float seeRange = 10f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;

    private float lastAttackTime = 0f;

    void Awake()
    {
        GameObject playerob = GameObject.FindGameObjectWithTag("Player");
        player = playerob.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= seeRange)
        {
            //Audio.instance.PlayDemonPatrol();
            agent.SetDestination(player.position);

            if (distance <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            agent.SetDestination(transform.position); // idle
        }
    }

    void Attack()
    {
        player.GetComponent<Health>().HurtPlayer(10);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seeRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
