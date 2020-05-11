using UnityEngine;

public class HeadUIHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats = null;

    private Animator animator = null;
    private int previousFrameHealth;
    void Start()
    {
        if (stats == null)
        {
            stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
        animator = GetComponent<Animator>();
        previousFrameHealth = stats.Health;
    }

    void Update()
    {
        if(stats.Health < previousFrameHealth)
        {
            animator.SetTrigger("TakeDamage");
        }
        previousFrameHealth = stats.Health;
        animator.SetFloat("Health", stats.Health);
    }
}
