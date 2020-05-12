using UnityEngine;

public class ZombiemanWanderAI : StateMachineBehaviour
{
    [SerializeField]
    private float aggroRadius = 10;

    [SerializeField]
    private float wanderDuretion = 1;

    [SerializeField]
    private Transform player = null;

    private Transform demon = null;

    private ZombiemanMovement controller = null;

    private Vector3 currentDirection;

    private float wanderDirectionChangeTimestamp;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        WanderInNewDirection();
        demon = animator.transform;
        controller = animator.gameObject.GetComponent<ZombiemanMovement>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ShouldEngage())
        {
            animator.gameObject.GetComponent<DemonStats>().SetTarget(player);
            animator.SetTrigger("ShouldEngage");
        }
        if (wanderDirectionChangeTimestamp < Time.time)
        {
            WanderInNewDirection();
        }
        controller.Move(currentDirection);
    }

    public bool ShouldEngage()
    {
        return (demon.position - player.position).magnitude < aggroRadius;
    }
    public void WanderInNewDirection()
    {
        currentDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        wanderDirectionChangeTimestamp = Time.time + wanderDuretion;
    }
}
