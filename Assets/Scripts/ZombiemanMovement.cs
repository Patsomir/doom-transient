using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class ZombiemanMovement : MonoBehaviour
{
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
    }

    public void MoveTo(Vector3 position)
    {
        agent.destination = position;
    }

    public void Move(Vector3 direction)
    {
        agent.destination = transform.position + direction;
    }
}
