using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class ZombiemanMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;

    [SerializeField]
    [Range(0.5f, 3)]
    private float speed = 1;

    private float initialSpeed;
    private float initialAngularSpeed;
    private float initialAccelaration;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        initialSpeed = agent.speed;
        initialAngularSpeed = agent.angularSpeed;
        initialAccelaration = agent.acceleration;
    }

    void Update()
    {
        agent.speed = initialSpeed * speed;
        agent.angularSpeed = initialAngularSpeed * speed;
        agent.acceleration = initialAccelaration * speed;

        MoveTo(player.position);
    }

    void MoveTo(Vector3 position)
    {
        agent.destination = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Yauch");
    }
}
