using System.Transactions;
using UnityEngine;
using UnityEngine.EventSystems;
using static AmmoType;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private PlayerStats ammo = null;

    private Weapon[] weapons = null;

    private int currentWeapon = 0;

    private float currentReloadTimestamp = 0;

    private Camera playerPosition = null;
    public bool IsRealoading() {
        return Time.time < currentReloadTimestamp;
    }
    public bool ShotThisFrame { get; private set; } = false;

    public const int weaponSlots = 6;

    void Start()
    {
        weapons = new Weapon[weaponSlots];
        EquipWeaponOnSlot(0, new Pistol());
        playerPosition = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsRealoading())
        {
            Shoot();
        } else
        {
            ShotThisFrame = false;
        }
    }

    public void Shoot()
    {
        bool wasSuccessful;
        ammo.useAmmo(weapons[currentWeapon].Type, weapons[currentWeapon].Cost, out wasSuccessful);
        ShotThisFrame = wasSuccessful;
        if (wasSuccessful)
        {
            Vector3 position = playerPosition.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, playerPosition.nearClipPlane));
            Vector3 direction = playerPosition.transform.forward;
            weapons[currentWeapon].ShootFrom(position, direction);
            currentReloadTimestamp = Time.time + weapons[currentWeapon].ReloadTime;
        }
    }

    public void EquipWeaponOnSlot(int slot, Weapon weapon)
    {
        if(slot < weaponSlots && slot >= 0)
        {
            weapon.Owner = transform;
            weapons[slot] = weapon;
        }

    }
}

class Pistol : Weapon
{
    public Pistol() : base(AmmoType.BULLET, 1, 10, 5, 0.5f) { }

    public override void ShootFrom(Vector3 position, Vector3 direction)
    {
        RaycastHit target;
        if(Physics.Raycast(position, direction, out target))
        {
            if (target.collider.CompareTag("Demon"))
            {
                DemonStats demon = target.collider.gameObject.GetComponent<DemonStats>();
                demon.TakeDamage(GetEffectiveDamage(), Owner);
            }
        }
    }
        
}
