using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Moves the player using the NavMeshAgent component 
/// in the forward direction of the camera.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {

    private float currentSpeed;
    private Vector3 velocity;
    private float velocityThreshold = 0.07f;

    [SerializeField]
    [Range(0.5f, 3)]
    private float walkingSpeed = 1;

    [SerializeField]
    [Range(0.5f, 3)]
    private float runningSpeed = 2;

    private float initialSpeed;
    private float initialAngularSpeed;
    private float initialAccelaration;

    private NavMeshAgent agent;

    private Vector3 forwardDirection = Vector3.forward;
    private Vector3 sidewaysDirection = Vector3.right;

    void Start() {
        currentSpeed = walkingSpeed;
        velocity = Vector3.zero;

        agent = GetComponent<NavMeshAgent>();

        initialSpeed = agent.speed;
        initialAngularSpeed = agent.angularSpeed;
        initialAccelaration = agent.acceleration;
    }

    void Update() {
        UpdateSpeed();

        agent.speed = initialSpeed * currentSpeed;
        agent.angularSpeed = initialAngularSpeed * currentSpeed;
        agent.acceleration = initialAccelaration * currentSpeed;

        UpdateVelocity();

        agent.destination = transform.position + velocity;
    }

    private void OnEnable() {
        CameraFollow.OnLookDirectionChanged += Move;
    }

    private void OnDisable() {
        CameraFollow.OnLookDirectionChanged -= Move;
    }

    private void Move(Vector3 forwardDirection, Vector3 sidewaysDirection) {
        this.forwardDirection = forwardDirection;
        this.sidewaysDirection = sidewaysDirection;
    }

    private void UpdateSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            currentSpeed = runningSpeed;
        } else
        {
            currentSpeed = walkingSpeed;
        }
    }

    private void UpdateVelocity()
    {
        Vector3 currentVelocity =
            (forwardDirection * Input.GetAxisRaw("Vertical")
            + sidewaysDirection * Input.GetAxisRaw("Horizontal")).normalized;

        if (currentVelocity.magnitude != 0)
        {
            velocity = currentVelocity;
        }
        else
        {
            Vector3 newVelocity = velocity - 3.5f * Time.deltaTime * velocity;
            if (newVelocity.magnitude < velocityThreshold || Vector3.Dot(velocity, newVelocity) < 0)
            {
                velocity = Vector3.zero;
            } else
            {
                velocity = newVelocity;
            }
        }
    }
}
