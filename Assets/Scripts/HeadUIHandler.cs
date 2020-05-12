using UnityEngine;

public class HeadUIHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats = null;

    private Animator animator = null;
    private int previousFrameHealth;


    [SerializeField]
    private float rageTimeout = 0.5f;

    private float rageTime = 0.0f;
    private float rageTimeoutTimestamp;


    void Start()
    {
        if (stats == null)
        {
            stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
        animator = GetComponent<Animator>();
        previousFrameHealth = stats.Health;
        rageTimeoutTimestamp = Time.time;
    }

    void Update()
    {
        if(stats.Health < previousFrameHealth)
        {
            animator.SetTrigger("TakeDamage");
        }
        previousFrameHealth = stats.Health;
        animator.SetFloat("Health", stats.Health);

        if (!HasRageTimedOut())
        {
            if (Input.GetMouseButtonDown(0))
            {
                IncrementRage();
                UpdateRageTimestamp();
            }
        } else
        {
            if (Input.GetMouseButtonDown(0))
            {
                UpdateRageTimestamp();
            }
            ResetRage();
        }

        animator.SetFloat("Rage", rageTime);
    }

    bool HasRageTimedOut()
    {
        return rageTimeoutTimestamp < Time.time;
    }

    void UpdateRageTimestamp()
    {
        rageTimeoutTimestamp = Time.time + rageTimeout;
    }

    void IncrementRage()
    {
        rageTime += Time.time - (rageTimeoutTimestamp - rageTimeout);
    }

    void ResetRage()
    {
        rageTime = 0;
    }

}
