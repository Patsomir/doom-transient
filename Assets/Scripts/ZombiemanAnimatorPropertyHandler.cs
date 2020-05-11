using UnityEngine;

public class ZombiemanAnimatorPropertyHandler : MonoBehaviour
{
    private Animator animator = null;
    private DemonStats stats = null;

    private int previousHealth;
    void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<DemonStats>();
        previousHealth = stats.Health;
    }

    void Update()
    {
        animator.SetInteger("Health", stats.Health);
        if(stats.Health < previousHealth)
        {
            animator.SetTrigger("TakeDamage");
        }
        previousHealth = stats.Health;
    }
}
