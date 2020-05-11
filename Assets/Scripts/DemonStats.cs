using System;
using UnityEngine;

public class DemonStats : MonoBehaviour
{
    [SerializeField]
    private int health = 20;

    void Start()
    {
        IsDead = false;
    }
    void Update()
    {
        
    }

    public int Health
    {
        get { return health; }
        private set { health = value; }
    }

    public bool IsDead
    {
        get;
        private set;
    }

    public void TakeDamage(int damage)
    {
        Health = Math.Max(0, health - damage);
        if(Health == 0)
        {
            IsDead = true;
        }
        Debug.Log(Health);
    }
}
