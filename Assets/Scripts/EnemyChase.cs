using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 20f;

    private NavMeshAgent agent;
    private Animator animator;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            agent.SetDestination(player.position);

            if (animator != null)
            {
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            agent.ResetPath();

            if (animator != null)
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}