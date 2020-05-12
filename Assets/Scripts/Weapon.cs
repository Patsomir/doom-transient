using UnityEngine;
using static AmmoType;
public abstract class Weapon
{
    public AmmoType Type { get; set; }
    public int Cost { get; set; }
    public float ReloadTime { get; set; }
    public int Damage { get; set; }
    public int Diviation { get; set; }
    public Transform Owner { get; set; } = null;
    public Weapon(AmmoType type, int cost, int damage, int diviation, float reloadTime, Transform owner = null)
    {
        Type = type;
        Cost = cost;
        ReloadTime = reloadTime;
        Damage = damage;
        Diviation = diviation;
        Owner = owner;
    }



    public int GetEffectiveDamage()
    {
        return Random.Range(Damage - Diviation, Damage + Diviation + 1);
    }
    public abstract void ShootFrom(Vector3 position, Vector3 direction);
}
