using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSupplier : MonoBehaviour
{
    [SerializeField]
    private Digit3UI health = null;

    [SerializeField]
    private Digit3UI armor = null;

    [SerializeField]
    private Digit3UI ammo = null;

    [SerializeField]
    private PlayerStats stats = null;

    void Start()
    {
        if(stats == null)
        {
            stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
    }

    void Update()
    {
        health.Number = stats.Health;
        armor.Number = stats.Armor;
        ammo.Number = stats.Bullets;
    }
}
