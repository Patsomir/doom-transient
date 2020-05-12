using UnityEngine;

public class ZombiemanBackOffAI : StateMachineBehaviour
{
    private DemonStats stats = null;

    private Vector3 currentDirection;

    private ZombiemanMovement controller = null;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stats = animator.gameObject.GetComponent<DemonStats>();
        controller = animator.gameObject.GetComponent<ZombiemanMovement>();
        Vector3 targetDirection = (stats.GetTargetPosition() - animator.transform.position).normalized;
        Vector3 sidewaysVector = Vector3.Cross(targetDirection, Vector3.up).normalized;
        sidewaysVector *= Random.Range(0, 2) * 2 - 1;
        currentDirection = (targetDirection + sidewaysVector).normalized;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.Move(currentDirection);
    }
}
