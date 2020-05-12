using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiemanDeadAI : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<ZombiemanMovement>().MoveTo(animator.transform.position);
        animator.gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }
}
