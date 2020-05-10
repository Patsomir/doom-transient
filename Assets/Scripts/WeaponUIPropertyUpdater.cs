using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUIPropertyUpdater : MonoBehaviour
{
    Animator animator = null;

    [SerializeField]
    PlayerStats player = null;

    [SerializeField]
    PlayerWeapons weapons = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("Speed", player.Speed);
        animator.SetBool("IsReloading", weapons.IsRealoading);
        if (weapons.ShotThisFrame)
        {
            animator.SetTrigger("Shoot");
        }
    }
}
