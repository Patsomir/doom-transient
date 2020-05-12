using System;
using UnityEngine;

public class DemonStats : MonoBehaviour
{
    [SerializeField]
    private int health = 20;

    private Transform target = null;

    public int Health
    {
        get { return health; }
        private set { health = value; }
    }

    public Vector3 GetTargetPosition()
    {
        return target.position;
    }

    public bool HasTarget()
    {
        return target != null;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void TakeDamage(int damage, Transform attacker)
    {
        Health = Math.Max(0, health - damage);
        target = attacker;
    }
}
