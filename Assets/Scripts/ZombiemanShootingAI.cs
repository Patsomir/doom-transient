using UnityEngine;

public class ZombiemanShootingAI : StateMachineBehaviour
{
    private DemonStats stats = null;

    private ZombiemanMovement controller = null;

    private ZombiemanWeapon weapon = null;

    [SerializeField]
    private float shootingDelay = 1.0f / 3.0f;

    private float shootingTimestamp;

    private bool hasShot = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasShot = false;
        stats = animator.gameObject.GetComponent<DemonStats>();
        controller = animator.gameObject.GetComponent<ZombiemanMovement>();
        weapon = animator.gameObject.GetComponent<ZombiemanWeapon>();
        controller.MoveTo(animator.transform.position);
        shootingTimestamp = Time.time + shootingDelay;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(shootingTimestamp < Time.time && !hasShot)
        {
            weapon.Shoot(stats.GetTargetPosition() - animator.transform.position);
            hasShot = true;
        }
    }
}
