using UnityEngine;

public class ZombiemanHurtAI : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<ZombiemanMovement>().MoveTo(animator.transform.position);
    }
}
