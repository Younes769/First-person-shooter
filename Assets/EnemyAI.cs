using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseDistance = 10f;
    public float attackDistance = 2f;
    public Transform[] patrolPoints; // Array of patrol points for the enemy to move between

    private Transform player; // Reference to the player's transform
    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private int currentPatrolIndex = 0; // Index of the current patrol point

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player GameObject
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        SetDestination(patrolPoints[currentPatrolIndex].position); // Set initial destination to the first patrol point
    }

    void Update()
    {
        if (player == null) // If the player GameObject is not found, return
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance) // If the player is within chase distance
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position); // Chase the player
        }
        else // If the player is outside chase distance
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f) // If the agent reached its destination
            {
                Patrol(); // Patrol between patrol points
            }
        }

        if (distanceToPlayer <= attackDistance) // If the player is within attack distance
        {
            // Implement attack logic here
            // For example, deal damage to the player
        }
    }

    void Patrol()
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Move to the next patrol point
        SetDestination(patrolPoints[currentPatrolIndex].position); // Set destination to the next patrol point
    }

    void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination); // Set the NavMeshAgent's destination
        agent.speed = patrolSpeed; // Set the agent's speed to patrol speed
    }
}
