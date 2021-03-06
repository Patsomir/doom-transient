﻿using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static AmmoType;
public class PlayerStats : MonoBehaviour
{
    private Transform player = null;
    private Vector3 previousPosition;
    private float speed;

    [SerializeField]
    private int maxHealth = 200;

    [SerializeField]
    private int maxArmor = 200;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private int armor = 0;

    [SerializeField]
    [Range(0, 1)]
    private float armorAbsorbtionRate = 1.0f / 3.0f;

    [SerializeField]
    private int[] ammo = { 40, 0, 0, 0 };
    
    void Start()
    {
        player = GetComponent<Transform>();
        previousPosition = player.position;
        Speed = 0;
    }

    void Update()
    {
        Speed = (player.position - previousPosition).magnitude / Time.deltaTime;
        previousPosition = player.position;
    }

    public int Health
    {
        get { return health; }
        private set { health = value; }
    }
    public int Armor
    {
        get { return armor; }
        private set { armor = value; }
    }
    public float Speed
    {
        get { return speed; }
        private set { speed = value; }
    }
    public int Bullets
    {
        get { return ammo[0]; }
        private set { ammo[0] = value; }
    }
    public int Shells
    {
        get { return ammo[1]; }
        private set { ammo[1] = value; }
    }
    public int Rockets
    {
        get { return ammo[2]; }
        private set { ammo[2] = value; }
    }
    public int Cells
    {
        get { return ammo[3]; }
        private set { ammo[3] = value; }
    }
 
    public void useAmmo(AmmoType type, int count, out bool isSuccessful)
    {
        if (ammo[(int)type] < count)
        {
            isSuccessful = false;
            return;
        }
        ammo[(int)type] -= count;
        isSuccessful = true;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void TakeDamage(int damage)
    {
        int armorDamage = (int) (damage * armorAbsorbtionRate);
        int healthDamage = damage - armorDamage;

        Armor -= armorDamage;
        if(Armor < 0)
        {
            healthDamage -= Armor;
            Armor = 0;
        }
        Health = Math.Max(0, Health - healthDamage);
    }

    public bool CanTakeHealth()
    {
        return Health < maxHealth && !IsDead();
    }

    public bool CanTakeArmor()
    {
        return Armor < maxArmor;
    }

    public void TakeHealth(int value)
    {
        Health = Math.Min(maxHealth, Health + value);
    }

    public void TakeArmor(int value)
    {
        Armor = Math.Min(maxArmor, Armor + value);
    }
}
