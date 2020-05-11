using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeVelocityCalculator : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    [SerializeField]
    [Range(0, 1)]
    private float diagonalWalkingThreshold = 0.2f;

    private Animator animator = null;

    private Vector3 previousPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
    }
    void Update()
    {
        Vector2 relativeVelocity = GetRelativeVelocity();
        animator.SetFloat("RelativeVelocityX", relativeVelocity.x);
        animator.SetFloat("RelativeVelocityZ", relativeVelocity.y);

    }

    public Vector2 GetRelativeVelocity()
    {
        Vector3 absoluteVelocity = (transform.position - previousPosition).normalized;
        Vector3 targetDirection = (target.position - transform.position).normalized;

        float determinant = targetDirection.x * absoluteVelocity.z -
                            absoluteVelocity.x * targetDirection.z;

        float relativeVelocityZ = -Mathf.Sign(Vector3.Dot(targetDirection, absoluteVelocity));
        float relativeVelocityX = Mathf.Sign(determinant);

        if (Mathf.Abs(determinant) < diagonalWalkingThreshold)
        {
            relativeVelocityX = 0;
        }
        if (Mathf.Abs(determinant) > 1 - diagonalWalkingThreshold)
        {
            relativeVelocityZ = 0;
        }

        previousPosition = transform.position;
        return new Vector2(relativeVelocityX, relativeVelocityZ);
    }
}
