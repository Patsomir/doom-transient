using UnityEngine;
using static AmmoType;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private PlayerStats ammo = null;

    private Weapon[] weapons = null;

    private int currentWeapon = 0;

    private float currentReloadTimestamp = 0;
    public bool IsRealoading { get; private set; } = false;
    public bool ShotThisFrame { get; private set; } = false;

    void Start()
    {
        weapons = new Weapon[6];
        weapons[0] = new Weapon(AmmoType.BULLET, 1, 0.5f);
    }
    void Update()
    {
        IsRealoading = Time.time < currentReloadTimestamp;

        if (Input.GetMouseButtonDown(0) && !IsRealoading)
        {
            bool wasSuccessful;
            ammo.useAmmo(weapons[currentWeapon].Type, weapons[currentWeapon].Cost, out wasSuccessful);
            ShotThisFrame = wasSuccessful;
            if (wasSuccessful)
            {
                currentReloadTimestamp = Time.time + weapons[currentWeapon].ReloadTime;
            }
        } else
        {
            ShotThisFrame = false;
        }
    }
}
