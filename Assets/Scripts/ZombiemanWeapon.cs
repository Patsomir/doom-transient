using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiemanWeapon : MonoBehaviour
{
    [SerializeField]
    private int damage = 9;

    [SerializeField]
    private int diviation = 6;

    [SerializeField]
    private float accuracyError = 10;

    public int GetEffectiveDamage()
    {
        return Random.Range(damage - diviation, damage + diviation);
    }

    public void Shoot(Vector3 direction)
    {
        float angle = Random.Range(-accuracyError, accuracyError) * Mathf.PI / 90;


        Vector3 actualDirection = new Vector3(direction.x * Mathf.Cos(angle) - direction.z * Mathf.Sin(angle),
                                              direction.y,
                                              direction.x * Mathf.Sin(angle) + direction.z * Mathf.Cos(angle));
        RaycastHit target;
        if (Physics.Raycast(transform.position, actualDirection, out target))
        {
            if (target.collider.CompareTag("Demon"))
            {
                DemonStats demon = target.collider.gameObject.GetComponent<DemonStats>();
                demon.TakeDamage(GetEffectiveDamage(), transform);
            } else if (target.collider.CompareTag("Player"))
            {
                PlayerStats player = target.collider.gameObject.GetComponent<PlayerStats>();
                player.TakeDamage(GetEffectiveDamage());
            }
        }
    }
}
