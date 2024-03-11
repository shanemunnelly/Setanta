using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float stoppingDistance = 2f; // Adjust this distance based on your preference

    Transform target;
    NavMeshAgent agent;
    Vector3 lastKnownPlayerPosition;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance; // Set the initial stopping distance
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < lookRadius && IsPlayerGrounded())
        {
            lastKnownPlayerPosition = target.position;

            // Check if the player is within the stopping distance
            if (distance <= agent.stoppingDistance)
            {
                agent.isStopped = true;
                FaceTarget();
            }
            else
            {
                agent.isStopped = false;
                // Adjust the stopping distance based on the desired space between the enemy and the player
                agent.stoppingDistance = Mathf.Max(stoppingDistance, distance - stoppingDistance);
                agent.SetDestination(lastKnownPlayerPosition);
            }
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(lastKnownPlayerPosition);
        }
    }

    bool IsPlayerGrounded()
    {
        CharacterController controller = target.GetComponent<CharacterController>();

        if (controller != null)
        {
            return controller.isGrounded;
        }

        return true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
