using UnityEngine;

public class ZombiemanTargetLocator : MonoBehaviour
{
    [SerializeField]
    private Transform origin = null;

    [SerializeField]
    [Range(0, 1)]
    private float diagonalShootingThreshold = 0.2f;

    private DemonStats target = null;

    private Animator animator = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GetComponent<DemonStats>();
        if (origin == null)
        {
            origin = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        if (target.HasTarget())
        {
            Vector2 relativeTargetLocation = GetRelativeTargetLocation();
            animator.SetFloat("RelativeTargetLocationX", relativeTargetLocation.x);
            animator.SetFloat("RelativeTargetLocationZ", relativeTargetLocation.y);
        }
    }

    public Vector2 GetRelativeTargetLocation()
    {
        Vector3 targetDirection = (target.GetTargetPosition() - transform.position).normalized;
        Vector3 originDirection = (origin.position - transform.position).normalized;

        float determinant = originDirection.x * targetDirection.z -
                            originDirection.z * targetDirection.x;

        float relativeTargetLocationZ = -Mathf.Sign(Vector3.Dot(originDirection, targetDirection));
        float relativeTargetLocationX = Mathf.Sign(determinant);

        if (Mathf.Abs(determinant) < diagonalShootingThreshold)
        {
            relativeTargetLocationX = 0;
        }
        if (Mathf.Abs(determinant) > 1 - diagonalShootingThreshold)
        {
            relativeTargetLocationZ = 0;
        }

        return new Vector2(relativeTargetLocationX, relativeTargetLocationZ);
    }
}
